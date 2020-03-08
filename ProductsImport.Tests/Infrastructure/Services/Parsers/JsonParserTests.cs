using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using Xunit;

namespace ProductsImport.Tests
{
    public class JsonParserTests
    {
        private JsonParser jsonParser;
        public JsonParserTests()
        {
            jsonParser = new JsonParser();
        }

        [Fact]
        public void ShouldCorrectlyParseJsonToObject()
        {
            // Act
            var productsObject = jsonParser.Parse<ProductsObject>(TestConstants.JsonFileText);

            // Assert
            Assert.NotNull(productsObject);
        }
    }
}
