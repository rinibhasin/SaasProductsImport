using ProductsImport.Infrastructure.Models;

namespace ProductsImport.Infrastructure.Services.Parsers
{
    public interface IInputParser
    {
        InputModel Parse(string input);
    }
}
