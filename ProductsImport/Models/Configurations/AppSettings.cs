using System.Collections.Generic;

namespace ProductsImport.Models.Configurations
{
    public class AppSettings
    {
        public IDictionary<string, string> Mappings { get; set; }
        public AppSettings()
        {
            Mappings = new Dictionary<string, string>();
        }

    }
}
