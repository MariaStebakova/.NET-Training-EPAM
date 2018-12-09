using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public abstract class Matrix<T>
    {
        protected Comparer<T> comparer;
        private int dimension;
        protected event EventHandler ElementChanged = delegate { };

        public int Dimension
        {
            get => dimension;
            protected set => dimension = value;
        }

        public T this[int i, int j]
        {
            get => GetValue(i, j);
            set => SetValue(i, j, value);
        }

        protected Matrix(int dimension)
        {
            if (dimension <= 0)
                throw new ArgumentException($"{nameof(dimension)} can't less than 1");

            this.dimension = dimension;
        }

        protected Matrix(T[,] elements)
        {
            if (elements == null)
                throw new ArgumentNullException($"{nameof(elements)} can't be null");

            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)) || !typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new ArgumentNullException($"Type {typeof(T)} has to implement IComparable interface");

            comparer = Comparer<T>.Default;
            CheckMatrix(elements);
            SetMatrix(elements);
        }

        protected Matrix(T[,] elements, Comparer<T> comparer)
        {
            if (elements == null)
                throw new ArgumentNullException($"{nameof(elements)} can't be null");

            this.comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} can't be null");

            CheckMatrix(elements);
            SetMatrix(elements);
        }

        protected abstract void SetMatrix(T[,] elements);

        protected abstract void CheckMatrix(T[,] elements);

        protected abstract void SetValue(int i, int j, T value);

        protected abstract T GetValue(int i, int j);

        protected void OnElementChanged(MatrixEventArgs eventArgs)
            => ElementChanged?.Invoke(this, eventArgs);

        protected void ChangeElement(int i, int j)
        {
            var message = new MatrixEventArgs($"Element has been changed on indexes i = {i} and j = {j}");
            OnElementChanged(message);
        }

        protected bool IsSquareMatrix(T[,] matrix) 
            => matrix.GetLength(0) == matrix.GetLength(1);

    }

    public class MatrixEventArgs : EventArgs
    {
        private string message;

        public string Message => message;

        public MatrixEventArgs(string message) => this.message = message;

    }
}
