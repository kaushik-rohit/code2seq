public CompletableFuture<List<TableEntry<byte[], byte[]>>> readTable(final String tableName,
                                                                         final List<TableKey<byte[]>> keys,
                                                                         String delegationToken,
                                                                         final long clientRequestId) {
        final CompletableFuture<List<TableEntry<byte[], byte[]>>> result = new CompletableFuture<>();
        final Controller.NodeUri uri = getTableUri(tableName);
        final WireCommandType type = WireCommandType.READ_TABLE;
        final long requestId = (clientRequestId == RequestTag.NON_EXISTENT_ID) ? idGenerator.get() : clientRequestId;

        final FailingReplyProcessor replyProcessor = new FailingReplyProcessor() {

            @Override
            public void connectionDropped() {
                log.warn(requestId, "readTable {} Connection dropped", tableName);
                result.completeExceptionally(
                        new WireCommandFailedException(type, WireCommandFailedException.Reason.ConnectionDropped));
            }

            @Override
            public void wrongHost(WireCommands.WrongHost wrongHost) {
                log.warn(requestId, "readTable {} wrong host", tableName);
                result.completeExceptionally(new WireCommandFailedException(type, WireCommandFailedException.Reason.UnknownHost));
            }

            @Override
            public void noSuchSegment(WireCommands.NoSuchSegment noSuchSegment) {
                log.warn(requestId, "readTable {} NoSuchSegment", tableName);
                result.completeExceptionally(new WireCommandFailedException(type, WireCommandFailedException.Reason.SegmentDoesNotExist));
            }

            @Override
            public void tableRead(WireCommands.TableRead tableRead) {
                log.debug(requestId, "readTable {} successful.", tableName);
                List<TableEntry<byte[], byte[]>> tableEntries = tableRead.getEntries().getEntries().stream()
                                                                         .map(e -> new TableEntryImpl<>(convertFromWireCommand(e.getKey()), getArray(e.getValue().getData())))
                                                                         .collect(Collectors.toList());
                result.complete(tableEntries);
            }

            @Override
            public void processingFailure(Exception error) {
                log.error(requestId, "readTable {} failed", tableName, error);
                handleError(error, result, type);
            }

            @Override
            public void authTokenCheckFailed(WireCommands.AuthTokenCheckFailed authTokenCheckFailed) {
                result.completeExceptionally(
                        new WireCommandFailedException(new AuthenticationException(authTokenCheckFailed.toString()),
                                                       type, WireCommandFailedException.Reason.AuthFailed));
            }
        };

        List<ByteBuf> buffersToRelease = new ArrayList<>();
        // the version is always NO_VERSION as read returns the latest version of value.
        List<WireCommands.TableKey> keyList = keys.stream().map(k -> {
            ByteBuf buffer = wrappedBuffer(k.getKey());
            buffersToRelease.add(buffer);
            return new WireCommands.TableKey(buffer, WireCommands.TableKey.NO_VERSION);
        }).collect(Collectors.toList());

        WireCommands.ReadTable request = new WireCommands.ReadTable(requestId, tableName, delegationToken, keyList);
        sendRequestAsync(request, replyProcessor, result, ModelHelper.encode(uri));
        return result
                .whenComplete((r, e) -> release(buffersToRelease));
    }