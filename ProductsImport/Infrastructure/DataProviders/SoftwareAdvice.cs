using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataProviders
{
    public class SoftwareAdvice : IDataProvider
    {
        public IParser parser { get; set; }
        public FileHelper Helper { get; set; }
        public SoftwareAdvice()
        {
            this.parser = new JsonParser();
            this.Helper = Helper;
        }

        public ProductsObject ParseInput()
        {
            return parser.Parse<ProductsObject>(this.Helper.ReadFileText(Constants.Capterra));
        }
    }
}
