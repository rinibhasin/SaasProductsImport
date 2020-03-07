using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataAccess
{
    public class MySqlDataAccess : IDataAccess
    {
        public int InsertProducts(ProductsObject products)
        {
            // MySql specific code for pushing the products into the database
            return products.Products.Count;
        }
    }
}
