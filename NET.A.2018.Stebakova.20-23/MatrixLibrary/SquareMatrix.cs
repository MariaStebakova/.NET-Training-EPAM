using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixLibrary
{
    public class SquareMatrix<T>: Matrix<T>
    {
        private T[,] innerMatrix;

        public SquareMatrix(int dimension) : base(dimension)
        {
            innerMatrix = new T[dimension, dimension];
        }

        public SquareMatrix(T[,] elements) : base(elements)
        {
        }

        public SquareMatrix(T[,] elements, Comparer<T> comparer) : base(elements, comparer)
        {
        }

        protected override void SetMatrix(T[,] elements)
        {
            int dimension = elements.GetLength(0);
            innerMatrix = new T[dimension, dimension];
            Dimension = dimension;

            for (int i = 0; i<dimension; i++)
            for (int j = 0; j < dimension; j++)
                innerMatrix[i, j] = elements[i, j];
        }

        protected override void CheckMatrix(T[,] elements)
        {
            if (!IsSquareMatrix(elements))
                throw new ArgumentException($"{elements} are not allowed for square matrix");
        }

        protected override void SetValue(int i, int j, T value)
        {
            innerMatrix[i, j] = value;
            ChangeElement(i, j);
        }

        protected override T GetValue(int i, int j)
        {
            return innerMatrix[i, j];
        }
    }
}
