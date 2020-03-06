using System;
using ProductsImport.Models;

namespace ProductsImport.Infrastructure.Services
{
    public class ConsoleLogger : IConsoleLogger
    {
        //  This method is used to display products
        public void DisplayProducts(ProductsObject products)
        {
            foreach (var product in products.Products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
