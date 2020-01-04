public static void replaceWhere(@NonNull INDArray to, @NonNull Number set, @NonNull Condition condition) {
        if (!(condition instanceof BaseCondition))
            throw new UnsupportedOperationException("Only static Conditions are supported");

        Nd4j.getExecutioner().exec(new CompareAndSet(to, set.doubleValue(), condition));
    }