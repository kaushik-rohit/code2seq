public SDVariable sizeAt(String name, SDVariable in, int dimension) {
        SDVariable ret = f().sizeAt(in, dimension);
        return updateVariableNameAndReference(ret, name);
    }