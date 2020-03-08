using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class SoftwareAdvice : IDataProvider
    {
        public IParser Parser { get; set; }
        public IFileHelper FileHelper { get; set; }
        public SoftwareAdvice(IFileHelper fileHelper)
        {
            this.Parser = Ioc.Container.ResolveKeyed<IParser>("json");
            this.FileHelper = fileHelper;
        }

        public ProductsObject ParseInput()
        {
            return Parser.Parse<ProductsObject>(this.FileHelper.ReadFileText(Constants.SoftwareAdvice));
        }
    }
}
