using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsImport.Infrastructure.Services.Parsers
{
    public interface IParser
    {
        T Parse<T>(string input);
    }
}
