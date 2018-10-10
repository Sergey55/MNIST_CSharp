using Xunit;
using Math.Numeric.Int;
using Assert = Xunit.Assert;

namespace Math.Tests.Numeric.Int
{
    public class MatrixTests
    {
        [Fact]
        public void Dimensions_Test()
        {
            var matrix = new Matrix(new int[,] { { 1, 2, 3, 4 } });

            Assert.Equal(1, matrix.RowCount);
            Assert.Equal(4, matrix.ColumnCount);
        }

        [Fact]
        public void AddScalarToMatrixInt_Test()
        {
            var scalar = 1;
            var matrix = new Matrix(new int[,]{{1, 1}, {1, 1}});

            var res = scalar + matrix;

            Assert.True(res[0, 0] == 2);
            Assert.True(res[0, 1] == 2);
            Assert.True(res[1, 0] == 2);
            Assert.True(res[1, 1] == 2);
        }

        [Fact]
        public void AddMatrixToMatrixInt_Test()
        {
            var matrix1 = new Matrix(new int[,] {{1, 2}, {3, 4}});
            var matrix2 = new Matrix(new int[,]{{5, 6}, {7, 8}});

            var res = matrix1 + matrix2;

            Assert.True(res[0, 0] == 6);
            Assert.True(res[0, 1] == 8);
            Assert.True(res[1, 0] == 10);
            Assert.True(res[1, 1] == 12);
        }
    }
}
