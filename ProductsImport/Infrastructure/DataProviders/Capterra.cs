using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.Collections.Generic;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class Capterra : IDataProvider
    {
        public IParser Parser { get; set; }

        public FileHelper Helper { get; set; }
        public Capterra()
        {
            this.Parser = new YamlParser();
            this.Helper = new FileHelper();
        }

        public ProductsObject ParseInput()
        {
            return new ProductsObject()
            {
                Products = Parser.Parse<List<Product>>(this.Helper.ReadFileText(Constants.Capterra))
            };
        }
    }
}
