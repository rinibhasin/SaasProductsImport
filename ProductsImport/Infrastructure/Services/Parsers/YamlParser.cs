using YamlDotNet.Serialization;

namespace ProductsImport.Infrastructure.Services.Parsers
{
    public class YamlParser : IParser
    {
        public T Parse<T>(string input)
        {
            return new Deserializer().Deserialize<T>(input);
        }
    }
}
