using Newtonsoft.Json;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ProductsImport.Models
{
    public class Product
    {
        [JsonIgnore]
        [YamlMember(Alias = "tags")]
        public string Tags { get; set; }


        [YamlIgnore]
        public List<string> Categories { get; set; }


        [YamlMember(Alias = "twitter")]
        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }


        [YamlMember(Alias = "name")]
        public string Title { get; set; }

        public override string ToString()
        {
            return $"importing: Name: {Title}; Categories: {(string.IsNullOrEmpty(Tags)? string.Join(",", Categories): Tags)}; Twitter: {Twitter}";
        }
    }
}
