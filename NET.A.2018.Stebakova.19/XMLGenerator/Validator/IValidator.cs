using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.Validator
{
    /// <summary>
    /// Interface for all validator types
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        /// Checks if <param name="source"></param> is valid in order to some rules
        /// </summary>
        /// <param name="source">Checked value</param>
        /// <returns>Result of checking</returns>
        bool IsValid(T source);
    }
}
