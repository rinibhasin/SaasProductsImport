using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ProductsImport.Infrastructure.Services
{
    public class FileHelper
    {
        public string ReadFile()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.FeedProducts, Constants.SoftwareAdvice);
            return File.ReadAllText(path);
        }
    }
}
