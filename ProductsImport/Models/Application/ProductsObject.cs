using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsImport.Models
{
    public class ProductsObject
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
