using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using XMLGenerator.DataProvider;
using XMLGenerator.DataService;
using XMLGenerator.Logger;
using XMLGenerator.Parser;
using XMLGenerator.Storage;
using XMLGenerator.Validator;

namespace XMLGenerator.Console
{
    public class Configuration: NinjectModule
    {
        private string sourceFile = @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\input.txt";
        private string resultFile =
            @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\output.xml";

        public override void Load()
        {
            Bind<IProvider<IEnumerable<string>>>().To<DataProvider.DataProvider>().WithConstructorArgument(sourceFile);
            Bind<ILogger>().To<NLogger>();
            Bind<IParser<string, Uri>>().To<Parser.UriParser>();
            Bind<IStorage<Uri>>().To<XMLStorage>().WithConstructorArgument(resultFile);
            Bind<IValidator<string>>().To<UriValidator>();
            Bind<IDataService>().To<TransferService<string, Uri>>();
        }
    }
}
