public Boolean ack(String taskId, String workerId) {
        Preconditions.checkArgument(StringUtils.isNotBlank(taskId), "Task id cannot be blank");

        String response = postForEntity("tasks/{taskId}/ack", null, new Object[]{"workerid", workerId}, String.class, taskId);
        return Boolean.valueOf(response);
    }