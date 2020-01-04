protected void deleteChildExecutions(ExecutionEntity parentExecution, boolean deleteExecution, CommandContext commandContext) {
    // Delete all child executions
    ExecutionEntityManager executionEntityManager = commandContext.getExecutionEntityManager();
    Collection<ExecutionEntity> childExecutions = executionEntityManager.findChildExecutionsByParentExecutionId(parentExecution.getId());
    if (CollectionUtil.isNotEmpty(childExecutions)) {
      for (ExecutionEntity childExecution : childExecutions) {
        deleteChildExecutions(childExecution, true, commandContext);
      }
    }

    if (deleteExecution) {
      executionEntityManager.deleteExecutionAndRelatedData(parentExecution, null, false);
    }
  }