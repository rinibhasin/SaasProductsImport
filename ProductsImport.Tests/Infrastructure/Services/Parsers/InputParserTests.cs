using ProductsImport.Infrastructure.Services.Parsers;
using System;
using Xunit;

namespace ProductsImport.Tests
{
    public class InputParserTests
    {
        private InputParser inputParser;
        public InputParserTests()
        {
            inputParser = new InputParser();
        }

        [Fact]
        public void ShouldCorrectlyParseInputStringToModel()
        {
            // Arrange
            var inputString = "import capterra feed-products/capterra.yaml";

            // Act
            var model = inputParser.Parse(inputString);

            // Assert
            Assert.Equal("capterra", model.CompanyName);
        }

        [Fact]
        public void ShouldThrowExceptionIfInputStringNotInCorrectFormat()
        {
            // Arrange
            var inputString = string.Empty;

            // Act
            Assert.Throws<Exception>(()=> inputParser.Parse(inputString));
        }
    }
}
