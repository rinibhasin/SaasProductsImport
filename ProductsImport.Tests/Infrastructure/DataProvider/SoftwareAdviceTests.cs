using FakeItEasy;
using ProductsImport.Infrastructure.DataProviders;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.Collections.Generic;
using Xunit;

namespace ProductsImport.Tests
{
    public class SoftwareAdviceTests
    {
        private SoftwareAdvice softwareAdvice;
        private IFileHelper mockFileHelper;
        private IIocContainer mockIocContainer;
        private IParser mockParser;

        public SoftwareAdviceTests()
        {
            mockFileHelper = A.Fake<IFileHelper>();
            mockIocContainer = A.Fake<IIocContainer>();
            mockParser = A.Fake<IParser>();
            A.CallTo(() => mockIocContainer.ResolveKeyed<IParser>(A<string>._)).Returns(mockParser);
            Ioc.Container = mockIocContainer;
        }

        [Fact]
        public void ShouldReturnZeroProductsWhenEmptyFileReceived()
        {
            // Arrange
            A.CallTo(() => mockFileHelper.ReadFileText(A<string>._)).Returns(string.Empty);
            A.CallTo(() => mockParser.Parse<ProductsObject>(A<string>._)).Returns(new ProductsObject());

            // Act
            softwareAdvice = new SoftwareAdvice(mockFileHelper);
            var output = softwareAdvice.ParseInput();

            // Assert
            A.CallTo(() => mockParser.Parse<ProductsObject>(A<string>._)).MustHaveHappened();
            Assert.Null(output.Products);
        }

        [Fact]
        public void ShouldReturnProductsWhenEmptyFileReceived()
        {
            // Arrange
            A.CallTo(() => mockFileHelper.ReadFileText(A<string>._)).Returns(TestConstants.JsonFileText);
            A.CallTo(() => mockParser.Parse<ProductsObject>(A<string>._)).Returns(GetProductObject());

            // Act
            softwareAdvice = new SoftwareAdvice(mockFileHelper);
            var output = softwareAdvice.ParseInput();

            // Assert
            A.CallTo(() => mockParser.Parse<ProductsObject>(A<string>._)).MustHaveHappened();
            Assert.Equal(3, output.Products.Count);
        }

        private ProductsObject GetProductObject()
        {
            var productsObject = new ProductsObject()
            {
                Products = GetProducts()
            };

            return productsObject;
        }

        private List<Product> GetProducts()
        {
            var products = new List<Product>();
            var product1 = new Product()
            {
                Title = "sample",
            };
            var product2 = new Product()
            {
                Title = "sample2"
            };

            products.Add(product1);
            products.Add(product2);
            products.Add(product1);

            return products;
        }
    }
}
