public Observable<T> submit(final ServerOperation<T> operation) {
        final ExecutionInfoContext context = new ExecutionInfoContext();
        
        if (listenerInvoker != null) {
            try {
                listenerInvoker.onExecutionStart();
            } catch (AbortExecutionException e) {
                return Observable.error(e);
            }
        }

        final int maxRetrysSame = retryHandler.getMaxRetriesOnSameServer();
        final int maxRetrysNext = retryHandler.getMaxRetriesOnNextServer();

        // Use the load balancer
        Observable<T> o = 
                (server == null ? selectServer() : Observable.just(server))
                .concatMap(new Func1<Server, Observable<T>>() {
                    @Override
                    // Called for each server being selected
                    public Observable<T> call(Server server) {
                        context.setServer(server);
                        final ServerStats stats = loadBalancerContext.getServerStats(server);
                        
                        // Called for each attempt and retry
                        Observable<T> o = Observable
                                .just(server)
                                .concatMap(new Func1<Server, Observable<T>>() {
                                    @Override
                                    public Observable<T> call(final Server server) {
                                        context.incAttemptCount();
                                        loadBalancerContext.noteOpenConnection(stats);
                                        
                                        if (listenerInvoker != null) {
                                            try {
                                                listenerInvoker.onStartWithServer(context.toExecutionInfo());
                                            } catch (AbortExecutionException e) {
                                                return Observable.error(e);
                                            }
                                        }
                                        
                                        final Stopwatch tracer = loadBalancerContext.getExecuteTracer().start();
                                        
                                        return operation.call(server).doOnEach(new Observer<T>() {
                                            private T entity;
                                            @Override
                                            public void onCompleted() {
                                                recordStats(tracer, stats, entity, null);
                                                // TODO: What to do if onNext or onError are never called?
                                            }

                                            @Override
                                            public void onError(Throwable e) {
                                                recordStats(tracer, stats, null, e);
                                                logger.debug("Got error {} when executed on server {}", e, server);
                                                if (listenerInvoker != null) {
                                                    listenerInvoker.onExceptionWithServer(e, context.toExecutionInfo());
                                                }
                                            }

                                            @Override
                                            public void onNext(T entity) {
                                                this.entity = entity;
                                                if (listenerInvoker != null) {
                                                    listenerInvoker.onExecutionSuccess(entity, context.toExecutionInfo());
                                                }
                                            }                            
                                            
                                            private void recordStats(Stopwatch tracer, ServerStats stats, Object entity, Throwable exception) {
                                                tracer.stop();
                                                loadBalancerContext.noteRequestCompletion(stats, entity, exception, tracer.getDuration(TimeUnit.MILLISECONDS), retryHandler);
                                            }
                                        });
                                    }
                                });
                        
                        if (maxRetrysSame > 0) 
                            o = o.retry(retryPolicy(maxRetrysSame, true));
                        return o;
                    }
                });
            
        if (maxRetrysNext > 0 && server == null) 
            o = o.retry(retryPolicy(maxRetrysNext, false));
        
        return o.onErrorResumeNext(new Func1<Throwable, Observable<T>>() {
            @Override
            public Observable<T> call(Throwable e) {
                if (context.getAttemptCount() > 0) {
                    if (maxRetrysNext > 0 && context.getServerAttemptCount() == (maxRetrysNext + 1)) {
                        e = new ClientException(ClientException.ErrorType.NUMBEROF_RETRIES_NEXTSERVER_EXCEEDED,
                                "Number of retries on next server exceeded max " + maxRetrysNext
                                + " retries, while making a call for: " + context.getServer(), e);
                    }
                    else if (maxRetrysSame > 0 && context.getAttemptCount() == (maxRetrysSame + 1)) {
                        e = new ClientException(ClientException.ErrorType.NUMBEROF_RETRIES_EXEEDED,
                                "Number of retries exceeded max " + maxRetrysSame
                                + " retries, while making a call for: " + context.getServer(), e);
                    }
                }
                if (listenerInvoker != null) {
                    listenerInvoker.onExecutionFailed(e, context.toFinalExecutionInfo());
                }
                return Observable.error(e);
            }
        });
    }