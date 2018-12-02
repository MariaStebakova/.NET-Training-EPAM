using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLGenerator.Storage
{
    /// <summary>
    /// Class that implements xml storaging functionality
    /// </summary>
    public class XMLStorage : IStorage<Uri>
    {
        private string filePath;

        /// <summary>
        /// .ctor for <see cref="XMLStorage"/> class
        /// </summary>
        /// <param name="storageName">Storage name</param>
        /// <exception cref="ArgumentException">Throws when <param name="storageName"></param> is equal to null or empty</exception>
        /// <exception cref="FileNotFoundException">Throws when there is no such file with <param name="storageName"></param></exception>
        public XMLStorage(string storageName)
        {
            if (String.IsNullOrEmpty(storageName))
                throw new ArgumentException($"{nameof(storageName)} can't be null or empty");

            if (!File.Exists(storageName))
                throw new FileNotFoundException($"{storageName} must exist");

            filePath = storageName;
        }

        /// <summary>
        /// Saves data to the xml storage
        /// </summary>
        /// <param name="values">Data to save</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="values"></param> is equal to null</exception>
        public void Save(IEnumerable<Uri> values)
        {
            if (values == null)
                throw new ArgumentNullException($"{nameof(values)} can't be null");

            SaveValues(values);
        }

        private void SaveValues(IEnumerable<Uri> values)
        {
            XDocument xDocument = new XDocument();
            XElement root = new XElement("urlAdresses");

            foreach (var u in values)
            {
                XElement element = new XElement("urlAdress");
                AddHost(element, u);
                AddUri(element, u);
                AddParams(element, u);
                root.Add(element);
            }

            xDocument.Add(root);
            xDocument.Save(filePath);
        }

        private void AddHost(XElement root, Uri uri)
        {
            XElement element = new XElement("host");
            XAttribute attribute = new XAttribute("name", uri.Host);
            element.Add(attribute);
            root.Add(element);
        }

        private void AddUri(XElement root, Uri uri)
        {
            XElement element = new XElement("uri");
            foreach (var item in uri.Segments.Where(x => x != "/"))
            {
                element.Add(new XElement("segment", item.Where(x => x != '/')));
            }

            root.Add(element);
        }

        private void AddParams(XElement root, Uri uri)
        {
            string queryString = uri.Query;
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);

            if (queryDictionary.HasKeys())
            {
                var keys = queryDictionary.AllKeys;

                XElement element = new XElement("parameters");
                for (int i = 0; i < queryDictionary.Count; i++)
                {
                    XElement param = new XElement("parametr");
                    XAttribute valueAttr = new XAttribute("value", queryDictionary[i]);
                    param.Add(valueAttr);

                    XAttribute keyAttr = new XAttribute("key", keys[i]);
                    param.Add(keyAttr);

                    element.Add(param);
                }

                root.Add(element);
            }
        }
    }
}
