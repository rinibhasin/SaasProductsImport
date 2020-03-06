using Autofac;
using ProductsImport.Infrastructure.DataAccess;
using ProductsImport.Infrastructure.DataProviders;
using ProductsImport.Infrastructure.Models;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;

namespace ProductsImport
{
    public class Engine : IEngine
    {
        public IContainer Container { get; set; }
        public IConsoleLogger ConsoleLogger { get; set; }

        public IInputParser InputParser { get; set; }

        public IDataAccess DataAccess { get; set; }

        public Engine(IConsoleLogger consoleLogger, IInputParser inputParser)
        {
            ConsoleLogger = consoleLogger;
            InputParser = inputParser;
        }

        public void Process(IContainer container)
        {
            var inputString = "import capterra feed-products/capterra.yaml";
            var inputModel = ParseInput(container, inputString);

            var provider = container.ResolveKeyed<IDataProvider>(inputModel.CompanyName);
            var products = provider.ParseInput();

            DataAccess = Container.ResolveKeyed<IDataAccess>("mysql");
            DataAccess.InsertProducts(products);

            ConsoleLogger.DisplayProducts(products);
        }
        private static InputModel ParseInput(IContainer container, string inputString)
        {
            var inputParser = container.Resolve<IInputParser>();
            return inputParser.Parse(inputString);
        }

    }
}
