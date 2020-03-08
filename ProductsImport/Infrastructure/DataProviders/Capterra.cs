using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.Collections.Generic;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class Capterra : IDataProvider
    {
        public IParser Parser { get; set; }
        public IFileHelper FileHelper { get; set; }

        public Capterra(IFileHelper fileHelper)
        {
            this.Parser = Ioc.Container.ResolveKeyed<IParser>("yaml");
            this.FileHelper = fileHelper;
        }

        public ProductsObject ParseInput()
        {
            return new ProductsObject()
            {
                Products = Parser.Parse<List<Product>>(this.FileHelper.ReadFileText(Constants.Capterra))
            };
        }
    }
}
