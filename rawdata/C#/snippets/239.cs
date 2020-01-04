public Decimal[] Solve(Decimal[] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.Length != rows)
                throw new DimensionMismatchException("value", "The vector should have the same length as rows in the decomposition.");

            if (!Nonsingular)
                throw new InvalidOperationException("Matrix is singular.");


            // Copy right hand side with pivoting
            int count = value.Length;
            var b = new Decimal[count];
            for (int i = 0; i < b.Length; i++)
                b[i] = value[pivotVector[i]];


            // Solve L*Y = B
            var X = new Decimal[count];
            for (int i = 0; i < rows; i++)
            {
                X[i] = b[i];
                for (int j = 0; j < i; j++)
                    X[i] -= lu[i, j] * X[j];
            }

            // Solve U*X = Y;
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = rows - 1; j > i; j--)
                    X[i] -= lu[i, j] * X[j];
                X[i] /= lu[i, i];
            }

            return X;
        }