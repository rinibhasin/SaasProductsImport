using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.IO;
using System.Reflection;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class Capterra : IDataProvider
    {
        public IParser parser { get; set; }
        public Capterra()
        {
            this.parser = new YamlParser();
        }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.FeedProducts, Constants.Capterra);
            string inputString = File.ReadAllText(path);
            var products = parser.Parse<ProductsObject>(inputString);
        }
    }
}
