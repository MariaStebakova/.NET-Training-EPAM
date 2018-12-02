using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLGenerator.DataProvider;
using XMLGenerator.Logger;
using XMLGenerator.Parser;
using XMLGenerator.Storage;

namespace XMLGenerator.DataService
{
    /// <summary>
    /// Class than implements data transfer service functionality
    /// </summary>
    /// <typeparam name="TSource">Input values type</typeparam>
    /// <typeparam name="TResult">Output values type</typeparam>
    public class TransferService<TSource, TResult> : IDataService
    {
        private readonly IProvider<IEnumerable<TSource>> _provider;
        private readonly IStorage<TResult> _storage;
        private readonly IParser<TSource, TResult> _parser;
        private readonly ILogger _logger;

        /// <summary>
        /// .ctor for <see cref="TransferService{TSource,TResult}"/> class
        /// </summary>
        /// <param name="provider">Data provider></param>
        /// <param name="storage">Storage</param>
        /// <param name="parser">Parser</param>
        /// <param name="logger">Parser</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <param name="provider"></param> is equal to null
        /// 2) <param name="storage"></param> is equal to null
        /// 3) <param name="parser"></param> is equal to null
        /// </exception>
        public TransferService(IProvider<IEnumerable<TSource>> provider, IStorage<TResult> storage, IParser<TSource, TResult> parser, ILogger logger)
        {
            _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)} can't be equal to null!");
            _storage = storage ?? throw new ArgumentNullException($"{nameof(storage)} can't be equal to null!");
            _parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} can't be equal to null!");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(parser)} can't be equal to null!");
        }

        /// <summary>
        /// Transfers data of one storage to another with some changes
        /// </summary>
        /// <exception cref="Exception">Parsing exception</exception>
        public void Transfer()
        {
            IEnumerable<TSource> providerData = _provider.GetData();
            List<TResult> storageData = new List<TResult>();

            foreach (var i in providerData)
            {
                try
                {
                    storageData.Add(_parser.Parse(i));
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                }
            }

            _storage.Save(storageData);
        }
    }
}
