using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsLibrary
{
    /// <summary>
    /// Class for working with binary search tree
    /// </summary>
    /// <typeparam name="T">Type of data of tree's nodes</typeparam>
    public class BinarySearchTree<T>: IEnumerable<T>
    {
        /// <summary>
        /// Class representing node for binary search tree
        /// </summary>
        /// <typeparam name="T">Type of data of the node</typeparam>
        public class Node<T>
        {
            /// <summary>
            /// Reference to the left child of the node
            /// </summary>
            public Node<T> Left { get; set; }

            /// <summary>
            /// Reference to the right child of the node
            /// </summary>
            public Node<T> Right { get; set; }

            /// <summary>
            /// Value of the node
            /// </summary>
            public T Data { get; }

            public Node(T value)
            {
                Data = value;
            }
        }

        private Node<T> root;
        private Comparison<T> comparison = Comparer<T>.Default.Compare;

        private int count;

        public int Count => count;

        /// <summary>
        /// Binary search tree ctor
        /// </summary>
        /// <param name="comparer"><see cref="Comparer{T}"/> of the <see cref="{T}"/> type</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="comparer"/> is equal to null</exception>
        public BinarySearchTree(Comparer<T> comparer)
        {
            if (comparer == null) 
                throw new ArgumentNullException($"{nameof(comparer)} can't be null");

            comparison = comparer.Compare;
        }

        /// <summary>
        /// Binary search tree ctor
        /// </summary>
        /// <param name="collection">Input collection of nodes of the tree</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="collection"/> is equal to null</exception>
        public BinarySearchTree(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException($"{nameof(collection)} can't be null");

            IEnumerator<T> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
                Insert(enumerator.Current);
        }

        /// <summary>
        /// Binary search tree ctor
        /// </summary>
        /// <param name="collection">Input collection of nodes of the tree</param>
        /// <param name="comparer"><see cref="Comparer{T}"/> of the <see cref="{T}"/> type</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="collection"/> or <paramref name="comparer"/> is equal to null</exception>
        public BinarySearchTree(IEnumerable<T> collection, Comparer<T> comparer)
        {
            if (collection == null)
                throw new ArgumentNullException($"{nameof(collection)} can't be null");

            if(comparer == null)
                throw new ArgumentNullException($"{nameof(comparer)} can't be null");

            comparison = comparer.Compare;
            IEnumerator<T> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
                Insert(enumerator.Current);
        }

        /// <summary>
        /// Clears the tree
        /// </summary>
        public void Clear()
        {
            root = null;
        }

        /// <summary>
        /// Adds the node to the tree
        /// </summary>
        /// <param name="value">Data of the adding node</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="value"/> is equal to null</exception>
        public void Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException($"{nameof(value)} can't be null");

            if (root == null)
            {
                root = new Node<T>(value);
                count++;
                return;
            }

            Node<T> current = root;
            bool isAdded = false;

            do
            {
                if (comparison(value, current.Data) >= 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>(value);
                        count++;
                        isAdded = true;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>(value);
                        count++;
                        isAdded = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            } while (!isAdded);
        }

        /// <summary>
        /// Validates if the tree contains <paramref name="value"/> node
        /// </summary>
        /// <param name="value">Data of the searched node</param>
        /// <returns>True if tree has node with <paramref name="value"/>, otherwise false</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="value"/> if equal to null</exception>
        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException($"{nameof(value)} can't be null");

            Node<T> current = root;

            while (current != null)
            {
                if (comparison(value, current.Data) == 0)
                    return true;

                if (comparison(value, current.Data) > 0)
                    current = current.Right;

                else
                    current = current.Left;
            }

            return false;
        }

        /// <summary>
        /// Implements the preorder bypass of the tree
        /// </summary>
        /// <returns>Collection of the nodes</returns>
        /// <exception cref="ArgumentNullException">Thrown if the current tree is empty</exception>
        public IEnumerable<T> PreOrder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            return GetOrder(root);

            IEnumerable<T> GetOrder(Node<T> node)
            {
                yield return node.Data;

                if (node.Left != null)
                {
                    foreach (var el in GetOrder(node.Left))
                    {
                        yield return el;
                    }
                }

                if (node.Right != null)
                {
                    foreach (var el in GetOrder(node.Right))
                    {
                        yield return el;
                    }
                }
            }
        }

        /// <summary>
        /// Implements the inorder bypass of the tree
        /// </summary>
        /// <returns>Collection of the nodes</returns>
        /// <exception cref="ArgumentNullException">Thrown if the current tree is empty</exception>
        public IEnumerable<T> InOrder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            return GetOrder(root);

            IEnumerable<T> GetOrder(Node<T> node)
            {
                if (node.Left != null)
                {
                    foreach (var el in GetOrder(node.Left))
                    {
                        yield return el;
                    }
                }

                yield return node.Data;

                if (node.Right != null)
                {
                    foreach (var el in GetOrder(node.Right))
                    {
                        yield return el;
                    }
                }
            }
        }
        
        /// <summary>
        /// Implements the postorder bypass of the tree
        /// </summary>
        /// <returns>Collection of the nodes</returns>
        /// <exception cref="ArgumentNullException">Thrown if the current tree is empty</exception>
        public IEnumerable<T> PostOrder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            return GetOrder(root);

            IEnumerable<T> GetOrder(Node<T> node)
            {
                if (node.Left != null)
                {
                    foreach (var el in GetOrder(node.Left))
                    {
                        yield return el;
                    }
                }

                if (node.Right != null)
                {
                    foreach (var el in GetOrder(node.Right))
                    {
                        yield return el;
                    }
                }

                yield return node.Data;
            }
        }

        /// <summary>
        /// Implementation of the <see cref="IEnumerable{T}"/> interface <see cref="GetEnumerator"/>
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
