public Decimal[,] SolveTranspose(Decimal[,] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.GetLength(0) != rows)
                throw new DimensionMismatchException("value", "The matrix should have the same number of rows as the decomposition.");

            if (!Nonsingular)
                throw new SingularMatrixException("Matrix is singular.");


            // Copy right hand side with pivoting
            var X = value.Submatrix(null, pivotVector);

            int count = X.GetLength(1);

            // Solve L*Y = B(piv,:)
            for (int k = 0; k < rows; k++)
                for (int i = k + 1; i < rows; i++)
                    for (int j = 0; j < count; j++)
                        X[j, i] -= X[j, k] * lu[i, k];

            // Solve U*X = Y;
            for (int k = rows - 1; k >= 0; k--)
            {
                for (int j = 0; j < count; j++)
                    X[j, k] /= lu[k, k];

                for (int i = 0; i < k; i++)
                    for (int j = 0; j < count; j++)
                        X[j, i] -= X[j, k] * lu[i, k];
            }

            return X;
        }