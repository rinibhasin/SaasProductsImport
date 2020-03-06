using ProductsImport.Models;

namespace ProductsImport.Infrastructure.Services
{
    public interface IConsoleLogger
    {
        void DisplayProducts(ProductsObject products);
    }
}
