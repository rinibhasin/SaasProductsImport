using ProductsImport.Models;

namespace ProductsImport.Infrastructure.DataAccess
{
    public class MongoDbDataAccess : IDataAccess
    {
        public int InsertProducts(ProductsObject products)
        {
            // Mongo Db specific code for pushing the products into the database
            return products.Products.Count;
        }
    }
}
