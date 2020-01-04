private List<EventExecution> executeEvent(String event, Message msg) throws Exception {
        List<EventHandler> eventHandlerList = metadataService.getEventHandlersForEvent(event, true);
        Object payloadObject = getPayloadObject(msg.getPayload());

        List<EventExecution> transientFailures = new ArrayList<>();
        for (EventHandler eventHandler : eventHandlerList) {
            String condition = eventHandler.getCondition();
            if (StringUtils.isNotEmpty(condition)) {
                logger.debug("Checking condition: {} for event: {}", condition, event);
                Boolean success = ScriptEvaluator.evalBool(condition, jsonUtils.expand(payloadObject));
                if (!success) {
                    String id = msg.getId() + "_" + 0;
                    EventExecution eventExecution = new EventExecution(id, msg.getId());
                    eventExecution.setCreated(System.currentTimeMillis());
                    eventExecution.setEvent(eventHandler.getEvent());
                    eventExecution.setName(eventHandler.getName());
                    eventExecution.setStatus(Status.SKIPPED);
                    eventExecution.getOutput().put("msg", msg.getPayload());
                    eventExecution.getOutput().put("condition", condition);
                    executionService.addEventExecution(eventExecution);
                    logger.debug("Condition: {} not successful for event: {} with payload: {}", condition, eventHandler.getEvent(), msg.getPayload());
                    continue;
                }
            }

            CompletableFuture<List<EventExecution>> future = executeActionsForEventHandler(eventHandler, msg);
            future.whenComplete((result, error) -> result.forEach(eventExecution -> {
                if (error != null || eventExecution.getStatus() == Status.IN_PROGRESS) {
                    executionService.removeEventExecution(eventExecution);
                    transientFailures.add(eventExecution);
                } else {
                    executionService.updateEventExecution(eventExecution);
                }
            })).get();
        }
        return transientFailures;
    }