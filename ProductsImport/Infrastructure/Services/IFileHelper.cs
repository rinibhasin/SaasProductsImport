using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsImport.Infrastructure.Services
{
    public interface IFileHelper
    {
        string ReadFileText(string fileName);
    }
}
