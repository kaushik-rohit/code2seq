public SDVariable relu(String name, SDVariable x, double cutoff) {
        validateFloatingPoint("ReLU", x);
        SDVariable result = f().relu(x, cutoff);
        return updateVariableNameAndReference(result, name);
    }