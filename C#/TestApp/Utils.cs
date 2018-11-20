using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class MatrixExtensions
    {
        public static int MaxValueIndex(this Math.Numeric.Matrix<double> matrix)
        {
            int index = 0;
            double max = 0.0;

            for (int i = 0; i < matrix.RowCount; i++)
            {
                if (matrix[i, 0] > max)
                {
                    index = i;
                    max = matrix[i, 0];
                }
            }

            return index;
        }
    }
}
