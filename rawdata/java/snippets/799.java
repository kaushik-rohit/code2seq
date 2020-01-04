public void addLossVariable(@NonNull String variableName){
        Preconditions.checkState(hasVariable(variableName), "No variable with name \"%s\" exists", variableName);
        SDVariable v = getVariable(variableName);
        Preconditions.checkState(v.dataType().isFPType(), "Only floating point type variables can be marked as losses to be minimized." +
                " SDVariable \"%s\" has datatype %s", variableName, v.dataType());
        Preconditions.checkState(v.getVariableType() == VariableType.ARRAY, "Only ARRAY type SDVariables can be marked as losses to be minimized." +
                " SDVariable \"%s\" has variable type %s", variableName, v.getVariableType());
        if(!lossVariables.contains(variableName)){
            lossVariables.add(variableName);
        }
    }