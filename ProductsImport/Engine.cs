using ProductsImport.Infrastructure.DataAccess;
using ProductsImport.Infrastructure.DataProviders;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models.Configurations;
using System;

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

        public void Process(AppSettings settings)
        {
            try
            {
                var inputString = "import softwareadvice feed-products/capterra.yaml";
                var inputModel = InputParser.Parse(inputString);

                /* Getting provider either capterra or 
                  software advice from input model and creating its
                  respective object*/
                var provider = Ioc.Container.ResolveKeyed<IDataProvider>(inputModel.CompanyName);
                var products = provider.ParseInput();

                /* Inserting products into the database*/
                DataAccess = Ioc.Container.ResolveKeyed<IDataAccess>(settings.Database);
                DataAccess.InsertProducts(products);

                ConsoleLogger.DisplayProducts(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
