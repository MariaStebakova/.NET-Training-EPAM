using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.Storage
{
    /// <summary>
    /// Interface for all storage types
    /// </summary>
    /// <typeparam name="T">Type of storage elements</typeparam>
    public interface IStorage<in T>
    {
        /// <summary>
        /// Save data in storage
        /// </summary>
        /// <param name="values">Data to save</param>
        void Save(IEnumerable<T> values);
    }
}
