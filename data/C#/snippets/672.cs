public Matrix<double> ToMatrix()
        {
            var matrix = new Matrix<double>(3, count);

            for (int i = 0; i < count; i++)
            {
                matrix[0, i] = Centers[i].X;
                matrix[1, i] = Centers[i].Y;
                matrix[2, i] = 1.0;
            }
            return matrix;
        }