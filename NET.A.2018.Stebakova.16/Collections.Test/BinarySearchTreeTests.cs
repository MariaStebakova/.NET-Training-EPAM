using System;
using System.Collections.Generic;
using Collections.Test.Test_Classes;
using CollectionsLibrary;
using NUnit.Framework;

namespace Collections.Test
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [TestCase(3, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        public bool ContainsIntTest(int value)
        {
            var binaryTree = CreateIntTree();
            return binaryTree.Contains(value);
        }

        [TestCase(2, ExpectedResult = 11)]
        [TestCase(7, ExpectedResult = 11)]
        public int InsertIntTest(int value)
        {
            var binaryTree = CreateIntTree();
            binaryTree.Insert(value);
            return binaryTree.Count;
        }

        [Test]
        public void PreOrderIntTest()
        {
            var binaryTree = CreateIntTree();
            int[] expected = new int[] { 3, 2, 1, 4, 3, 5, 4, 7, 5, 8 };
            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }

        [Test]
        public void InOrderIntTest()
        {
            var binaryTree = CreateIntTree();
            int[] expected = new int[] { 1, 2, 3, 3, 4, 4, 5, 5, 7, 8 };
            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        [Test]
        public void InOrderIntTest_WithCustomComparer()
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 }, Comparer<int>.Create(compare));

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, tree.InOrder());
        }

        [Test]
        public void PostOrderIntTest()
        {
            var binaryTree = CreateIntTree();
            int[] expected = new int[] { 1, 2, 3, 4, 5, 8, 7, 5, 4, 3 };
            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        private BinarySearchTree<int> CreateIntTree()
        {
            int[] array = new[] { 3, 2, 4, 1, 5, 3, 7, 5, 8, 4 };
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(array);
            return binarySearchTree;
        }

        [TestCase("vasya", ExpectedResult = true)]
        [TestCase("test", ExpectedResult = false)]
        public bool ContainsStringTest(string value)
        {
            var binaryTree = CreateStringTree();
            return binaryTree.Contains(value);
        }

        [Test]
        public void InOrderStringTest()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.InOrder());
        }

        [Test]
        public void InOrderStringTest_WithCustomComparer()
        {
            int compare(string a, string b)
            {
                if (a.CompareTo(b) > 0) return 1;
                if (a.CompareTo(b) < 0) return -1;
                return 0;
            }

            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" }, Comparer<string>.Create(compare));
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_String_DefaultComparer_PreOrder_IsCorrect()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_String_DefaultComparer_PostOrder_IsCorrect()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "2", "3", "4", "1" }, tree.PostOrder());
        }

        private BinarySearchTree<string> CreateStringTree()
        {
            string[] array = new[] { "masha", "vasya", "petya", "ilya", "sasha" };
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(array);
            return binarySearchTree;
        }

        [TestCase(3, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        public bool ContainsBookTest(int data)
        {
            Book searched = new Book(data);
            var tree = CreateBookTree();

            return tree.Contains(searched);
        }

        [Test]
        public void InOrderBookTest()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            var tree = CreateBookTree();
            CollectionAssert.AreEqual(books, tree.InOrder());
        }

        [Test]
        public void InOrderBookTest_WithCustomComparer()
        {
            int compare(Book a, Book b)
            {
                if (a.Cost > b.Cost) return 1;
                if (a.Cost < b.Cost) return -1;
                return 0;
            }

            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            var tree = CreateBookTree();
            CollectionAssert.AreEqual(books, tree.InOrder());
        }

        [Test]
        public void PreOrderBookTest()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            var tree = CreateBookTree();
            CollectionAssert.AreEqual(books, tree.PreOrder());
        }

        [Test]
        public void PostOrderBookTest()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            var tree = CreateBookTree();
            CollectionAssert.AreEqual(new Book[] { books[1], books[2], books[3], books[0] }, tree.PostOrder());
        }

        private BinarySearchTree<Book> CreateBookTree()
        {
            Book[] array = new[] { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(array);
            return binarySearchTree;
        }
    }
}
