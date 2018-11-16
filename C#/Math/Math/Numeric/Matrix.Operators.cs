using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Math.Numeric
{
    public partial class Matrix<T>
    {
        public static Matrix<T> operator +(T scalar, Matrix<T> rightMatrix)
        {
            return rightMatrix.Add(scalar);
        }

        public static Matrix<T> operator +(Matrix<T> rightMatrix, T scalar)
        {
            return rightMatrix.Add(scalar);
        }

        public static Matrix<T> operator +(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return leftMatrix.Add(rightMatrix);
        }

        public static Matrix<T> operator -(T scalar, Matrix<T> rightMatrix)
        {
            return rightMatrix.Subtract(scalar);
        }

        public static Matrix<T> operator -(Matrix<T> rightMatrix, T scalar)
        {
            return rightMatrix.Subtract(scalar);
        }

        public static Matrix<T> operator -(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return leftMatrix.Subtract(rightMatrix);
        }

        public static Matrix<T> operator *(T scalar, Matrix<T> rightMatrix)
        {
            return rightMatrix.Multiply(scalar);
        }

        public static Matrix<T> operator *(Matrix<T> leftMatrix, T scalar)
        {
            return leftMatrix.Multiply(scalar);
        }

        public static Matrix<T> operator *(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return leftMatrix.Multiply(rightMatrix);
        }
    }
}
