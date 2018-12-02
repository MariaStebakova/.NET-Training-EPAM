using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.DataProvider
{
    /// <summary>
    /// Class that implements data provider functionality
    /// </summary>
    public class DataProvider: IProvider<IEnumerable<string>>
    {
        private string filePath;

        /// <summary>
        /// .ctor for <see cref="DataProvider"/> class
        /// </summary>
        /// <param name="filePath">Input file name for data provider file</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="filePath"></param> is equal to null or empty</exception>
        /// <exception cref="FileNotFoundException">Throws when there is no such file with <param name="filePath"></param></exception>
        public DataProvider(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentException($"{nameof(filePath)} can't be null or empty");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{filePath} has to exist");

            this.filePath = filePath;
        }

        /// <summary>
        /// Gets whole data from the storage
        /// </summary>
        /// <returns>Collection of data</returns>
        public IEnumerable<string> GetData()
        {
            List<string> lines = new List<string>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (TextReader tr = new StreamReader(fs))
            {
                while (tr.Peek() > -1)
                    lines.Add(tr.ReadLine());
            }

            return lines;
        }
    }
}
