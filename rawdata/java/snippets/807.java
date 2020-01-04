public SDVariable permute(String name, SDVariable x, int... dimensions) {
        SDVariable result = f().permute(x, dimensions);
        return updateVariableNameAndReference(result, name);
    }