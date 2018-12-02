using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLGenerator.Validator;

namespace XMLGenerator.Parser
{
    /// <summary>
    /// Class that parse some data for uri
    /// </summary>
    public class UriParser: IParser<string, Uri>
    {
        private IEnumerable<IValidator<string>> validators;

        /// <summary>
        /// .ctor for <see cref="UriParser"/> class
        /// </summary>
        /// <param name="validators">Needed validators</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="validators"></param> is equal to null</exception>
        public UriParser(params IValidator<string>[] validators)
        {
            if (validators == null)
                throw new ArgumentNullException($"{nameof(validators)} can't be null");

            this.validators = validators.ToList();
        }

        /// <summary>
        /// Parses <param name="source"/>
        /// </summary>
        /// <param name="source">Parsing value</param>
        /// <exception cref="UriFormatException">Throws when <param name="source"></param> isn't in correct URI form</exception>
        /// <returns>Parsed value</returns>
        public Uri Parse(string source)
        {
            foreach (var validator in validators)
            {
                if (!validator.IsValid(source))
                    throw new UriFormatException($"{nameof(source)} is not valid Uri!");
            }

            return new Uri(source);
        }
    }
}
