using System;
using System.Text;

namespace PolynomialLibrary
{
    /// <summary>
    /// Public sealed class for working with polynomials
    /// </summary>
    public sealed class Polynomial: ICloneable, IEquatable<Polynomial>
    {
        private double[] polinomialCoefficients;

        private const double delta = 1e-10;

        /// <summary>
        /// Constructor for polynomial
        /// </summary>
        /// <param name="coefficients">Array of double coefficients of the polynomial</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException($"{nameof(coefficients)} can't be equal to null.");
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException($"{nameof(coefficients)} can't be empty!");
            }

            polinomialCoefficients = new double[coefficients.Length];
            coefficients.CopyTo(polinomialCoefficients, 0);
        }

        /// <summary>
        /// Property for getting power of the polynomial
        /// </summary>
        public int Power
        {
            get => Length - 1;
        }

        /// <summary>
        /// Property for getting length of the polynomial's coefficient array
        /// </summary>
        public int Length
        {
            get => polinomialCoefficients.Length; 
        }

        /// <summary>
        /// Property for getting access to the coefficient array
        /// </summary>
        public double[] CoefficientsArray
        {
            get => polinomialCoefficients;    
        }

        /// <summary>
        /// Implemened method of the ICloneable
        /// </summary>
        /// <returns>Clone object</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Public method for cloning current polynomial
        /// </summary>
        /// <returns>The clone polynomial of the current</returns>
        public Polynomial Clone()
        {
            return new Polynomial(polinomialCoefficients);
        }

        /// <summary>
        /// Implementation of the IEquatable.Equals
        /// </summary>
        /// <param name="otherPolynomial">The polynomial object for checking for equality</param>
        /// <returns>True if polymomials are equal, false if not</returns>
        public bool Equals(Polynomial otherPolynomial)
        {
            if (ReferenceEquals(this, otherPolynomial))
            {
                return true;
            }

            if (this is null || otherPolynomial is null)
            {
                return false;
            }

            if (Power != otherPolynomial.Power)
            {
                return false;
            }

            if (Power != otherPolynomial.Power)
            {
                return false;
            }

            for (int i = 0; i < otherPolynomial.Length; i++)
            {
                if (Math.Abs(otherPolynomial.CoefficientsArray[i] - polinomialCoefficients[i]) > delta)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Overrided method of the System.Object for getting the string representation of the polynomial
        /// </summary>
        /// <returns>String of the polynomial</returns>
        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException($"Object can't be equal to null!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = polinomialCoefficients.Length - 1; i >= 0; i--)
            {

                if (polinomialCoefficients[i] != 0)
                {
                    if (i == 0)
                    {
                        result.Append(polinomialCoefficients[i]);
                    }
                    else
                    {
                        if (i != 1)
                        {
                            result.Append(polinomialCoefficients[i] + "x^" + i + " + ");
                        }
                        else
                        {
                            if (polinomialCoefficients[i - 1] != 0 && i - 1 != -1)
                            {
                                result.Append(polinomialCoefficients[i] + "x" + " + ");
                            }
                            else
                            {
                                result.Append(polinomialCoefficients[i] + "x");
                            }
                        }
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Overrided method of the System.Object to provide comparison to the input object
        /// </summary>
        /// <param name="obj">Object to which comparison has to be provided</param>
        /// <returns>Boolean result of the comparison</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this is null || obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            /*var otherPolynomial = (Polynomial) obj;
            if (Power != otherPolynomial.Power)
            {
                return false;
            }

            for (int i = 0; i < otherPolynomial.Length; i++)
            {
                if (Math.Abs(otherPolynomial.CoefficientsArray[i] - polinomialCoefficients[i]) > delta)
                {
                    return false;
                }
            }*/

            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Overrided method of the System.Object for getting the hash code of the polynomial
        /// </summary>
        /// <returns>Hash code of the polynomial</returns>
        public override int GetHashCode()
        {
            return CoefficientsArray.GetHashCode();
        }

        /// <summary>
        /// Overloaded addition operation for two polynomials 
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>Result polynomial of the addition</returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckInput(firstPolynomial);
            CheckInput(secondPolynomial);

            return Sum(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Overloaded substraction operation for two polynomials 
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>Result polynomial of the substraction</returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckInput(firstPolynomial);
            CheckInput(secondPolynomial);

            return Substract(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Overloaded multiplication operation for two polynomials 
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>Result polynomial of the multiplication</returns>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckInput(firstPolynomial);
            CheckInput(secondPolynomial);

            return Multiply(firstPolynomial, secondPolynomial);
        }

        /// <summary>
        /// Overloaded comparison operation for two polynomials 
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>True if polynomials are equal</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
            => firstPolynomial.Equals(secondPolynomial);

        /// <summary>
        /// Overloaded comparison operation for two polynomials 
        /// </summary>
        /// <param name="firstPolynomial">First polynomial</param>
        /// <param name="secondPolynomial">Second polynomial</param>
        /// <returns>True if polynomials are not equal</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
            => !(firstPolynomial == secondPolynomial);

        private static Polynomial Sum(Polynomial firstPol, Polynomial secondPol)
        {
            var biggerPolynomial = (firstPol.Length > secondPol.Length) ? firstPol : secondPol;
            var lessPolynomial = (firstPol.Length < secondPol.Length) ? firstPol : secondPol;
            double[] result = new double[biggerPolynomial.Length];
            biggerPolynomial.CoefficientsArray.CopyTo(result, 0);

            for (int i = 0; i < lessPolynomial.Length; i++)
            {
                result[i] = firstPol.CoefficientsArray[i] + secondPol.CoefficientsArray[i];
            }

            return new Polynomial(result);
        }

        private static Polynomial Substract(Polynomial firstPol, Polynomial secondPol)
        {
            var biggerPolynomial = (firstPol.Length > secondPol.Length) ? firstPol : secondPol;
            var lessPolynomial = (firstPol.Length < secondPol.Length) ? firstPol : secondPol;
            double[] result = new double[biggerPolynomial.Length];
            biggerPolynomial.CoefficientsArray.CopyTo(result, 0);

            for (int i = 0; i < lessPolynomial.Length; i++)
            {
                result[i] = firstPol.CoefficientsArray[i] - secondPol.CoefficientsArray[i];
            }

            if (secondPol.Length > firstPol.Length)
            {
                for (int i = firstPol.Length; i < secondPol.Length; i++)
                {
                    result[i] = -result[i];
                }
            }
            return new Polynomial(result);
        }

        private static Polynomial Multiply(Polynomial firstPol, Polynomial secondPol)
        {
            double[] result = new double[firstPol.Length + secondPol.Length - 1];

            for (int i = 0; i < firstPol.Length; ++i)
            {
                for (int j = 0; j < secondPol.Length; ++j)
                {
                    result[i + j] += firstPol.CoefficientsArray[i] * secondPol.CoefficientsArray[j];
                }
            }

            return new Polynomial(result);
        }

        private static void CheckInput(Polynomial poly)
        {
            if (poly == null)
            {
                throw new ArgumentNullException($"{nameof(poly)} is null!");
            }

            if (poly.Length == 0)
            {
                throw new ArgumentException($"{nameof(poly)} is empty!");
            }
        }
    }
}
