namespace Math.Numeric.Int
{
    public class Matrix : Matrix<int>
    {
        public Matrix(int rows, int cols) : base(rows, cols)
        { }

        public Matrix(int[,] data) : base(data)
        { }

        public override object Clone()
        {
            return Data.Clone();
        }

        protected override Matrix<int> Build()
        {
            return new Matrix(RowCount, ColumnCount);
        }

        protected override Matrix<int> Build(int rows, int cols)
        {
            return new Matrix(rows, cols);
        }

        protected override void DoAdd(int scalar, Matrix<int> result)
        {
            Map(result, (a) => scalar + a);
        }

        protected override void DoAdd(Matrix<int> other, Matrix<int> result)
        {
            Map(other, result, (a, b) => a + b);
        }

        protected override void DoSubstract(int scalar, Matrix<int> result)
        {
            Map(result, (a) => a - scalar);
        }

        protected override void DoSubstractFromScalar(int scalar, Matrix<int> result)
        {
            Map(result, (a) => scalar - a);
        }

        protected override void DoSubstract(Matrix<int> other, Matrix<int> result)
        {
            Map(other, result, (a, b) => a - b);
        }

        protected override void DoMultiply(int scalar, Matrix<int> result)
        {
            Map(result, (a) => scalar * a);
        }

        protected override void DoMultiply(Matrix<int> other, Matrix<int> result)
        {
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < other.ColumnCount; j++)
                {
                    var amount = 0;

                    for (var k = 0; k < ColumnCount; k++)
                    {
                        amount += this[i, k] * other[k, j];
                    }

                    result[i, j] = amount;
                }
            }
        }

        protected override void DoPointwiseMultiply(Matrix<int> other, Matrix<int> result)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    result[i, j] = this[i, j] * other[i, j];
                }
            }
        }

        //protected override void DoSubtract(int scalar, Matrix<int> result)
        //{
        //    Map(result, (a) => scalar - a);
        //}
    }
}
