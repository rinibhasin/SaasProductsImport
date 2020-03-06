using System;
using System.IO;
using System.Reflection;

namespace ProductsImport.Infrastructure.Services
{
    public class FileHelper
    {
        public String ReadFileText(string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.FeedProducts, fileName);
            return File.ReadAllText(path);
        }
    }
}
