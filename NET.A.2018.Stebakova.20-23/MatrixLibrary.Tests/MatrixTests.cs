using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixLibrary.Tests
{
    [TestClass]
    public class MatrixTests
    {
        int[,] firstSquareMartix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] secondSquareMartix = { { -1, -2, -3 }, { -4, -5, -6 }, { -7, -8, -9 } };

        int[,] firstSymmetricMatrix = { { 1, 4, 5 }, { 4, 2, 6 }, { 5, 6, 3 } };
        int[,] secondSymmetricMatrix = { { -1, 1, 1 }, { 1, -2, 1 }, { 1, 1, -3 } };

        private int[,] firstDiagonalMatrix = { {1, 0, 0}, {0, 2, 0}, {0, 0, 3} };
        private int[,] secondDiagonalMatrix = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        [TestMethod]
        public void SumOfSquareMatrixes()
        {
            var fsm = new SquareMatrix<int>(firstSquareMartix);
            var ssm = new SquareMatrix<int>(secondSquareMartix);
            var result = fsm.Add(ssm);

            CollectionAssert.AreEqual(new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, 
                new int[,] { 
                    { result[0, 0], result[0, 1], result[0, 2] }, 
                    { result[1, 0], result[1, 1], result[1, 2] },
                    { result[2, 0], result[2, 1], result[2, 2] }
                });
        }

        [TestMethod]
        public void SumOfDiagonalMatrixes()
        {
            var fdm = new DiagonalMatrix<int>(firstDiagonalMatrix);
            var sdm = new DiagonalMatrix<int>(secondDiagonalMatrix);
            var result = fdm.Add(sdm);

            CollectionAssert.AreEqual(new int[,] { { 2, 0, 0 }, { 0, 3, 0 }, { 0, 0, 4 } },
                new int[,] {
                    { result[0, 0], result[0, 1], result[0, 2] },
                    { result[1, 0], result[1, 1], result[1, 2] },
                    { result[2, 0], result[2, 1], result[2, 2] }
                });
        }

        [TestMethod]
        public void SumOfSymmetricMatrixes()
        {
            var fsm = new SymmetricMatrix<int>(firstSymmetricMatrix);
            var ssm = new SymmetricMatrix<int>(secondSymmetricMatrix);
            var result = fsm.Add(ssm);

            CollectionAssert.AreEqual(new int[,] { { 0, 5, 6 }, { 5, 0, 7 }, { 6, 7, 0 } },
                new int[,] {
                    { result[0, 0], result[0, 1], result[0, 2] },
                    { result[1, 0], result[1, 1], result[1, 2] },
                    { result[2, 0], result[2, 1], result[2, 2] }
                });
        }
		
		//TODO: sq+sym, sq+diag, sym+diag
    }
}
