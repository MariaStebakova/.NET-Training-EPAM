using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class SymmetricMatrix<T>: Matrix<T>
    {
        private T[][] innerJaggedArray;

        public SymmetricMatrix(int dimension) : base(dimension)
        {
            innerJaggedArray = new T[dimension][];

            for (int i = 0; i < dimension; i++)
            {
                innerJaggedArray[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(T[,] elements) : base(elements)
        {
        }

        public SymmetricMatrix(T[,] elements, Comparer<T> comparer) : base(elements, comparer)
        {
        }

        protected override void SetMatrix(T[,] elements)
        {
            int dimension = elements.GetLength(0);
            innerJaggedArray = new T[dimension][];
            Dimension = dimension;

            for (int i = 0; i < dimension; i++)
            {
                innerJaggedArray[i] = new T[i + 1];

                for (int j = 0; j <= i; j++)
                {
                    innerJaggedArray[i][j] = elements[i, j];
                }
            }
        }

        protected override void CheckMatrix(T[,] elements)
        {
            if (!IsSquareMatrix(elements))
                throw new ArgumentException($"{elements} are not allowed for square matrix");

            if (!IsSymmetricMatrix(elements))
                throw new ArgumentException($"{elements} are not allowed for symmetric matrix");
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i == j)
                innerJaggedArray[i][j] = value;
            else
            {
                if (j >= innerJaggedArray[i].Length)
                    innerJaggedArray[j][i] = value;
                else
                    innerJaggedArray[i][j] = value;
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (j >= innerJaggedArray[i].Length)
                return innerJaggedArray[j][i];

            return innerJaggedArray[i][j];
        }

        private bool IsSymmetricMatrix(T[,] elements)
        {
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    if (comparer.Compare(elements[i, j], elements[j, i]) != 0)
                        return false;
                }
            }

            return true;
        }
    }
}
