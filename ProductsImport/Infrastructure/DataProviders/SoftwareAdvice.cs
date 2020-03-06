using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.IO;
using System.Reflection;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class SoftwareAdvice : IDataProvider
    {
        public IParser parser { get; set; }
        public SoftwareAdvice()
        {
            this.parser = new JsonParser();
        }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.FeedProducts, Constants.SoftwareAdvice);
            string inputString = File.ReadAllText(path);
            var products = parser.Parse<ProductsObject>(inputString);
        }
    }
}
