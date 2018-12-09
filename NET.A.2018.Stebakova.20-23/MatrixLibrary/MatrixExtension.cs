using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixLibrary
{
    public static class MatrixExtension
    {
        public static Matrix<T> Add<T>(this Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Dimension != secondMatrix.Dimension)
                throw new ArgumentException($"Dimensions of matrixes {nameof(firstMatrix)} and {nameof(secondMatrix)} must be equal");

            Matrix<T> result;

            try
            {
                result = Add<T>((dynamic) firstMatrix, (dynamic) secondMatrix);
            }
            catch (RuntimeBinderException exception)
            {
                throw new InvalidOperationException($"The type {typeof(T)} doesn't support plus operator", exception);
            }

            return result;
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(firstMatrix.Dimension);

            SumFullMatrix(firstMatrix, secondMatrix, resultMatrix);

            return resultMatrix;
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(firstMatrix.Dimension);

            SumFullMatrix(firstMatrix, secondMatrix, resultMatrix);

            return resultMatrix;
        }

        private static SquareMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix) 
            => Add(secondMatrix, firstMatrix);

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
        {
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(firstMatrix.Dimension);

            SumFullMatrix(firstMatrix, secondMatrix, resultMatrix);

            return resultMatrix;
        }

        private static SquareMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
            => Add(secondMatrix, firstMatrix);

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
        {
            SymmetricMatrix<T> resultMatrix = new SymmetricMatrix<T>(firstMatrix.Dimension);

            SumFullMatrix(firstMatrix, secondMatrix, resultMatrix);

            return resultMatrix;
        }

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            SymmetricMatrix<T> resultMatrix = new SymmetricMatrix<T>(firstMatrix.Dimension);

            SumFullMatrix(firstMatrix, secondMatrix, resultMatrix);

            return resultMatrix;
        }

        private static SymmetricMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
            => Add(secondMatrix, firstMatrix);

        private static DiagonalMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            DiagonalMatrix<T> resultMatrix = new DiagonalMatrix<T>(firstMatrix.Dimension);

            dynamic fm = (dynamic)firstMatrix;
            dynamic sm = (dynamic)secondMatrix;

            for (int i = 0; i < resultMatrix.Dimension; i++)
            {
                resultMatrix[i, i] = fm[i, i] + sm[i, i];
            }

            return resultMatrix;
        }

        private static void SumFullMatrix<T>(Matrix<T> firstMatrix, Matrix<T> secondMatrix, Matrix<T> resultMatrix)
        {
            dynamic fm = (dynamic) firstMatrix;
            dynamic sm = (dynamic) secondMatrix;
            int dimension = resultMatrix.Dimension;

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    resultMatrix[i, j] = fm[i, j] + sm[i, j];
                }
            }

        }
    }
}
