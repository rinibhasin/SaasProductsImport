using ProductsImport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsImport.Infrastructure.DataProviders
{
    public interface IDataProvider
    {
        ProductsObject ParseInput();
    }
}
