using Xunit;
using Math.Numeric.Double;

namespace Math.Tests.Numeric.Double
{
    public class MatrixTests_Double
    {
        [Fact]
        public void Dimensions_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2, 3, 4 } });

            Assert.Equal(1, matrix.RowCount);
            Assert.Equal(4, matrix.ColumnCount);
        }

        [Fact]
        public void AddScalarToMatrix_Double_Test()
        {
            var scalar = 1;
            var matrix = new Matrix(new double[,] { { 1, 1 }, { 1, 1 } });

            var res = matrix + scalar;

            Assert.True(res[0, 0] == 2);
            Assert.True(res[0, 1] == 2);
            Assert.True(res[1, 0] == 2);
            Assert.True(res[1, 1] == 2);
        }

        [Fact]
        public void AddMatrixToScalar_Double_Test()
        {
            var scalar = 1;
            var matrix = new Matrix(new double[,] { { 1, 1 }, { 1, 1 } });

            var res = scalar + matrix;

            Assert.True(res[0, 0] == 2);
            Assert.True(res[0, 1] == 2);
            Assert.True(res[1, 0] == 2);
            Assert.True(res[1, 1] == 2);
        }

        [Fact]
        public void AddMatrixToMatrix_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });

            var res = matrix1 + matrix2;

            Assert.True(res[0, 0] == 6);
            Assert.True(res[0, 1] == 8);
            Assert.True(res[1, 0] == 10);
            Assert.True(res[1, 1] == 12);
        }

        [Fact]
        public void AddMatrixToMatrixException_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var matrix2 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            Assert.Throws<System.Exception>(() => {
                var result = matrix1 + matrix2;
            });
        }

        [Fact]
        public void SubstractScalarFromMatrix_Double_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            var result = matrix - 2;

            Assert.True(result[0, 0] == -1);
            Assert.True(result[0, 1] == 0);
            Assert.True(result[0, 2] == 1);
            Assert.True(result[1, 0] == 2);
            Assert.True(result[1, 1] == 3);
            Assert.True(result[1, 2] == 4);
        }

        [Fact]
        public void SubstractMatrixFromScalar_Double_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            var result = 2 - matrix;

            Assert.True(result[0, 0] == 1);
            Assert.True(result[0, 1] == 0);
            Assert.True(result[0, 2] == -1);
            Assert.True(result[1, 0] == -2);
            Assert.True(result[1, 1] == -3);
            Assert.True(result[1, 2] == -4);
        }

        [Fact]
        public void SubstractMatrixFromMatrix_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });

            var result = matrix2 - matrix1;

            Assert.True(result[0, 0] == 4);
            Assert.True(result[0, 1] == 4);

            Assert.True(result[1, 0] == 4);
            Assert.True(result[1, 1] == 4);
        }

        [Fact]
        public void SubstractMatrixToMatrixException_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var matrix2 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            Assert.Throws<System.Exception>(() => {
                var result = matrix1 - matrix2;
            });
        }

        [Fact]
        public void MultiplyMatrixOnScalar_Double_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            var result = matrix * 3;

            Assert.True(result[0, 0] == 3);
            Assert.True(result[0, 1] == 6);
            Assert.True(result[1, 0] == 9);
            Assert.True(result[1, 1] == 12);
        }

        [Fact]
        public void MultiplyScalarOnMatrix_Double_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            var result = 3 * matrix;

            Assert.True(result[0, 0] == 3);
            Assert.True(result[0, 1] == 6);
            Assert.True(result[1, 0] == 9);
            Assert.True(result[1, 1] == 12);
        }

        [Fact]
        public void MultiplyMatrixOnMatrix_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 3 }, { 1, 2 } });
            var matrix2 = new Matrix(new double[,] { { 1, 2, 1 }, { 3, 1, 0 } });

            var result = matrix1 * matrix2;

            Assert.True(result.RowCount == 2);
            Assert.True(result.ColumnCount == 3);

            Assert.True(result[0, 0] == 10);
            Assert.True(result[0, 1] == 5);
            Assert.True(result[0, 2] == 1);

            Assert.True(result[1, 0] == 7);
            Assert.True(result[1, 1] == 4);
            Assert.True(result[1, 2] == 1);
        }

        [Fact]
        public void MultiplyMatrixToMatrixException_Double_Test()
        {
            var matrix1 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var matrix2 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            Assert.Throws<System.Exception>(() => {
                var result = matrix1 * matrix2;
            });
        }

        [Fact]
        public void TransposeMatrix_Double_Test()
        {
            var matrix = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            var result = matrix.Transpose();

            Assert.True(result[0, 0] == 1);
            Assert.True(result[0, 1] == 4);
            Assert.True(result[1, 0] == 2);
            Assert.True(result[1, 1] == 5);
            Assert.True(result[2, 0] == 3);
            Assert.True(result[2, 1] == 6);
        }
    }
}
