using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class DiagonalMatrix<T>: Matrix<T>
    {
        private T[] diagonal;

        public DiagonalMatrix(int dimension) : base(dimension)
        {
            diagonal = new T[dimension];
        }

        public DiagonalMatrix(T[,] elements) : base(elements)
        {
        }

        public DiagonalMatrix(T[,] elements, Comparer<T> comparer) : base(elements, comparer)
        {
        }

        protected override void SetMatrix(T[,] elements)
        {
            int matrixDimension = elements.GetLength(0);
            diagonal = new T[matrixDimension];
            Dimension = matrixDimension;

            for (int i = 0; i < matrixDimension; i++)
                diagonal[i] = elements[i, i];
        }

        protected override void CheckMatrix(T[,] elements)
        {
            if (!IsSquareMatrix(elements))
                throw new ArgumentException($"{nameof(elements)} are not allowed for square matrix");

            if (!IsDiagonalMatrix(elements))
                throw new ArgumentException($"{nameof(elements)} are not allowed for diagonal matrix");
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
                throw new ArgumentException("You can't change other elements except diagonal in diagonal matrix");

            diagonal[i] = value;
            ChangeElement(i, j);
        }

        protected override T GetValue(int i, int j)
        {
            if (i != j)
                return default(T);

            return diagonal[i];
        }

        private bool IsDiagonalMatrix(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; i < matrix.GetLength(1); j++)
                {
                    if (i != j && comparer.Compare(matrix[i, j], default(T)) != 0)
                        return false;
                }
            }
                
            return true;
        }
    }
}
