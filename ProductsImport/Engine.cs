using ProductsImport.Infrastructure.DataAccess;
using ProductsImport.Infrastructure.DataProviders;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;

namespace ProductsImport
{
    public class Engine : IEngine
    {
        public IConsoleLogger ConsoleLogger { get; set; }

        public IInputParser InputParser { get; set; }

        public IDataAccess DataAccess { get; set; }

        public Engine(IConsoleLogger consoleLogger, IInputParser inputParser)
        {
            ConsoleLogger = consoleLogger;
            InputParser = inputParser;
        }

        public void Process()
        {
            var inputString = "import capterra feed-products/capterra.yaml";
            var inputModel = InputParser.Parse(inputString);

            var provider = Ioc.ResolveKeyed<IDataProvider>(inputModel.CompanyName);
            var products = provider.ParseInput();

            DataAccess = Ioc.ResolveKeyed<IDataAccess>("mysql");
            DataAccess.InsertProducts(products);

            ConsoleLogger.DisplayProducts(products);
        }
    }
}
