using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.Parser
{
    /// <summary>
    /// Interface for all data parsers
    /// </summary>
    /// <typeparam name="TSource">Input type result</typeparam>
    /// <typeparam name="TResult">Output type result</typeparam>
    public interface IParser<in TSource, out TResult>
    {
        /// <summary>
        /// Parses <param name="source"/>
        /// </summary>
        /// <param name="source">Parsing value</param>
        /// <returns>Parsed value</returns>
        TResult Parse(TSource source);
    }
}
