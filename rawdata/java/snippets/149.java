public static INDArray symmetricGeneralizedEigenvalues(INDArray A, INDArray B) {
        Preconditions.checkArgument(A.isMatrix() && A.isSquare(), "Argument A must be a square matrix: has shape %s", A.shape());
        Preconditions.checkArgument(B.isMatrix() && B.isSquare(), "Argument B must be a square matrix: has shape %s", B.shape());
        INDArray W = Nd4j.create(A.rows());

        A = InvertMatrix.invert(B, false).mmuli(A);
        Nd4j.getBlasWrapper().syev('V', 'L', A, W);
        return W;
    }