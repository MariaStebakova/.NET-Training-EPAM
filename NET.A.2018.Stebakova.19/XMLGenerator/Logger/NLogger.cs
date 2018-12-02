using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.Logger
{
    /// <summary>
    /// Class than implement logger functionality using NLog
    /// </summary>
    public class NLogger: ILogger
    {
        private const string LoggerFileName = "log.txt";
        private readonly NLog.Logger logger;

        /// <summary>
        /// .ctor for <see cref="NLogger"/> class
        /// </summary>
        public NLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = LoggerFileName };

            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        /// <summary>
        /// Log debug data
        /// </summary>
        /// <param name="message">info message</param>
        public void Debug(string message) => logger.Debug(message);

        /// <summary>
        /// Log error data
        /// </summary>
        /// <param name="message">info message</param>
        public void Error(string message) => logger.Error(message);

        /// <summary>
        /// Log fatal data
        /// </summary>
        /// <param name="message">info message</param>
        public void Fatal(string message) => logger.Fatal(message);

        /// <summary>
        /// Log info data
        /// </summary>
        /// <param name="message">info message</param>
        public void Info(string message) => logger.Info(message);

        /// <summary>
        /// Log warn data
        /// </summary>
        /// <param name="message">info message</param>
        public void Warn(string message) => logger.Warn(message);
    }
}
