using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.Logger
{
    /// <summary>
    /// Interface for all loggers
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log info data
        /// </summary>
        /// <param name="message">info message</param>
        void Info(string message);

        /// <summary>
        /// Log warn data
        /// </summary>
        /// <param name="message">info message</param>
        void Warn(string message);

        /// <summary>
        /// Log debug data
        /// </summary>
        /// <param name="message">info message</param>
        void Debug(string message);

        /// <summary>
        /// Log error data
        /// </summary>
        /// <param name="message">info message</param>
        void Error(string message);

        /// <summary>
        /// Log fatal data
        /// </summary>
        /// <param name="message">info message</param>
        void Fatal(string message);
    }
}
