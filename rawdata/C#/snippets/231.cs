public Decimal[,] Solve(Decimal[,] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.GetLength(0) != rows)
                throw new DimensionMismatchException("value", "The matrix should have the same number of rows as the decomposition.");

            if (!Nonsingular)
                throw new InvalidOperationException("Matrix is singular.");


            // Copy right hand side with pivoting
            int count = value.GetLength(1);
            Decimal[,] X = value.Submatrix(pivotVector, null);


            // Solve L*Y = B(piv,:)
            for (int k = 0; k < cols; k++)
                for (int i = k + 1; i < cols; i++)
                    for (int j = 0; j < count; j++)
                        X[i, j] -= X[k, j] * lu[i, k];

            // Solve U*X = Y;
            for (int k = cols - 1; k >= 0; k--)
            {
                for (int j = 0; j < count; j++)
                    X[k, j] /= lu[k, k];

                for (int i = 0; i < k; i++)
                    for (int j = 0; j < count; j++)
                        X[i, j] -= X[k, j] * lu[i, k];
            }

            return X;
        }