using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataProviders
{
    public interface IDataProvider
    {
        ProductsObject ParseInput();
    }
}
