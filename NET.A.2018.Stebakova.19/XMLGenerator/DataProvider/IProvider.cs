using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.DataProvider
{
    /// <summary>
    /// Interface for all data providers types
    /// </summary>
    /// <typeparam name="T">Output type</typeparam>
    public interface IProvider<out T>
    {
        /// <summary>
        /// Gets whole data from the storage
        /// </summary>
        /// <returns>Data</returns>
        T GetData();
    }
}
