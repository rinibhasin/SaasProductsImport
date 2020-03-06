using Newtonsoft.Json;

namespace ProductsImport.Infrastructure.Services.Parsers
{
    public class JsonParser : IParser
    {
        public T Parse<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
