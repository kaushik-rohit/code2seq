protected void setVariable(String variableName, Object value, ExecutionEntity sourceExecution, boolean fetchAllVariables) {

    if (fetchAllVariables == true) {

      // If it's in the cache, it's more recent
      if (usedVariablesCache.containsKey(variableName)) {
        updateVariableInstance(usedVariablesCache.get(variableName), value, sourceExecution);
      }

      // If the variable exists on this scope, replace it
      if (hasVariableLocal(variableName)) {
        setVariableLocal(variableName, value, sourceExecution, true);
        return;
      }

      // Otherwise, go up the hierarchy (we're trying to put it as high as possible)
      VariableScopeImpl parentVariableScope = getParentVariableScope();
      if (parentVariableScope != null) {
        if (sourceExecution == null) {
          parentVariableScope.setVariable(variableName, value);
        } else {
          parentVariableScope.setVariable(variableName, value, sourceExecution, true);
        }
        return;
      }

      // We're as high as possible and the variable doesn't exist yet, so
      // we're creating it
      if (sourceExecution != null) {
        createVariableLocal(variableName, value, sourceExecution);
      } else {
        createVariableLocal(variableName, value);
      }

    } else {

      // Check local cache first
      if (usedVariablesCache.containsKey(variableName)) {

        updateVariableInstance(usedVariablesCache.get(variableName), value, sourceExecution);

      } else if (variableInstances != null && variableInstances.containsKey(variableName)) {

        updateVariableInstance(variableInstances.get(variableName), value, sourceExecution);

      } else {

        // Not in local cache, check if defined on this scope
        // Create it if it doesn't exist yet
        VariableInstanceEntity variable = getSpecificVariable(variableName);
        if (variable != null) {
          updateVariableInstance(variable, value, sourceExecution);
          usedVariablesCache.put(variableName, variable);
        } else {

          VariableScopeImpl parent = getParentVariableScope();
          if (parent != null) {
            if (sourceExecution == null) {
              parent.setVariable(variableName, value, fetchAllVariables);
            } else {
              parent.setVariable(variableName, value, sourceExecution, fetchAllVariables);
            }

            return;
          }

          variable = createVariableInstance(variableName, value, sourceExecution);
          usedVariablesCache.put(variableName, variable);

        }

      }

    }

  }