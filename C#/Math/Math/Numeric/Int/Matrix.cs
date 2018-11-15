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

        protected override void DoSubtract(int scalar, Matrix<int> result)
        {
            Map(result, (a) => scalar - a);
        }

        protected override void DoSubtract(Matrix<int> other, Matrix<int> result)
        {
            Map(other, result, (a, b) => a - b);
        }

        protected override void DoMultiply(int scalar, Matrix<int> result)
        {
            throw new System.NotImplementedException();
        }

        protected override void DoMultiply(Matrix<int> other, Matrix<int> result)
        {
            throw new System.NotImplementedException();
        }

        //protected override void DoSubtract(int scalar, Matrix<int> result)
        //{
        //    Map(result, (a) => scalar - a);
        //}
    }
}
