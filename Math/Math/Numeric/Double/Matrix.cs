﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Math.Numeric.Double
{
    public class Matrix : Matrix<double>
    {
        public Matrix(int rows, int cols) 
            : base(rows, cols)
        {
        }

        public Matrix(double[,] data) 
            : base(data)
        {
        }

        public override object Clone()
        {
            return Data.Clone();
        }

        protected override Matrix<double> Build()
        {
            return new Matrix(RowCount, ColumnCount);
        }

        protected override void DoAdd(double scalar, Matrix<double> result)
        {
            Map(result, (a) => scalar + a);
        }

        protected override void DoAdd(Matrix<double> other, Matrix<double> result)
        {
            Map(other, result, (a, b) => a + b);
        }

        protected override void DoSubtract(double scalar, Matrix<double> result)
        {
            Map(result, (a) => scalar - a);
        }

        protected override void DoSubtract(Matrix<double> other, Matrix<double> result)
        {
            Map(other, result, (a, b) => a - b);
        }

        protected override void DoMultiply(double scalar, Matrix<double> result)
        {
            throw new NotImplementedException();
        }

        protected override void DoMultiply(Matrix<double> other, Matrix<double> result)
        {
            throw new NotImplementedException();
        }
    }
}