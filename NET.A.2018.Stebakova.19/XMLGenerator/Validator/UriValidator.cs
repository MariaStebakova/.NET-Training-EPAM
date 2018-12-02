using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XMLGenerator.Validator
{
    /// <summary>
    /// Class that implements uris validation
    /// </summary>
    public class UriValidator:IValidator<string>
    {
        private const string UriPattern = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        /// <summary>
        /// Checks if <param name="value"></param> is valid to some rules
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <returns>Result of checking</returns>
        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, UriPattern, RegexOptions.IgnoreCase);
        }
    }
}
