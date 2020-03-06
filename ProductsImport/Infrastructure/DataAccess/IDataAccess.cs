using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataAccess
{
    public interface IDataAccess
    {
        void InsertProducts(ProductsObject products);
    }
}
