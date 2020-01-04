@Service
    public void skipTaskFromWorkflow(String workflowId, String taskReferenceName,
                                     SkipTaskRequest skipTaskRequest) {
        workflowExecutor.skipTaskFromWorkflow(workflowId, taskReferenceName, skipTaskRequest);
    }