namespace ProductsImport.Infrastructure.Services.Parsers
{
    public interface IParser
    {
        T Parse<T>(string input);
    }
}
