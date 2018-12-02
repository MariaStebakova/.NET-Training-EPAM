using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using XMLGenerator.DataService;
using XMLGenerator.Storage;
using XMLGenerator.Validator;

namespace XMLGenerator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string sourceFile = @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\input.txt";
            string resultFile =
                @"D:\Стажировка\EPAM\Tasks\.NET-Training-EPAM\NET.A.2018.Stebakova.19\XMLGenerator.Console\bin\Debug\output.xml";

            var service = new TransferService<string, Uri>(new DataProvider.DataProvider(sourceFile), new XMLStorage(resultFile), new XMLGenerator.Parser.UriParser(new UriValidator()));
            */

            IKernel kernel = new StandardKernel(new Configuration());

            var service = kernel.Get<IDataService>();

            service.Transfer();
        }
    }
}
