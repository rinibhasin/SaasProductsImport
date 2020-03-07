using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataAccess
{
    public interface IDataAccess
    {
        int InsertProducts(ProductsObject products);
    }
}
