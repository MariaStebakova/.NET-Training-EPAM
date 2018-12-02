using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using XMLGenerator.DataProvider;
using XMLGenerator.DataService;
using XMLGenerator.Logger;
using XMLGenerator.Parser;
using XMLGenerator.Storage;
using XMLGenerator.Validator;

namespace XMLGenerator.Test
{
    [TestFixture]
    public class TransferServiceTests
    {
        private static string sourceFile = @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\input.txt";
        private static string resultFile =
            @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\output.xml";

        IProvider<IEnumerable<string>> provider = new DataProvider.DataProvider(sourceFile);
        ILogger logger = new NLogger();
        IParser<string, Uri> parser = new Parser.UriParser(new UriValidator());
        IStorage<Uri> storage = new XMLStorage(resultFile);
        IDataService dataService;

        string httpsPath = $"https://github.com/AnzhelikaKravchuk?tab=repositories";

        [Test]
        public void DataProviderTest_VerifyGetData()
        {
            IEnumerable<string> collection = new List<string> { httpsPath };
            var mock = new Mock<IProvider<IEnumerable<string>>>();
            mock.Setup(d => d.GetData()).Returns(collection);
            dataService = new TransferService<string, Uri>(mock.Object, storage, parser, logger);
            mock.Verify();
        }

        [Test]
        public void LoggerTest_VerifyWarn()
        {
            var mock = new Mock<ILogger>();
            mock.Setup(d => d.Warn(It.IsAny<string>()));
            dataService = new TransferService<string, Uri>(provider, storage, parser, mock.Object);
            mock.Verify();
        }

        [Test]
        public void StorageTest_VerifySave()
        {
            var mock = new Mock<IStorage<Uri>>();
            mock.Setup(d => d.Save(It.IsAny<IEnumerable<Uri>>()));
            dataService = new TransferService<string, Uri>(provider, storage, parser, logger);
            mock.Verify();
        }

        [Test]
        public void ParserTest_VerifySave()
        {
            var mock = new Mock<IParser<string, Uri>>();
            mock.Setup(d => d.Parse(It.IsAny<string>())).Returns(new Uri(httpsPath));
            dataService = new TransferService<string, Uri>(provider, storage, mock.Object, logger);
            mock.Verify();
        }

        [Test]
        public void ValidatorTest_VerifySave()
        {
            var mock = new Mock<IValidator<string>>();
            mock.Setup(d => d.IsValid(It.IsAny<string>())).Returns(true);
            dataService = new TransferService<string, Uri>(provider, storage, new Parser.UriParser(mock.Object), logger);
            mock.Verify();
        }
    }
}
