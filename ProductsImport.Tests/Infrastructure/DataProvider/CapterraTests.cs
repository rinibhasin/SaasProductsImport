using Autofac;
using FakeItEasy;
using ProductsImport.Infrastructure.DataProviders;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Infrastructure.Services.Parsers;
using ProductsImport.Models;
using System.Collections.Generic;
using Xunit;

namespace ProductsImport.Tests
{
    public class CapterraTests
    {
        private Capterra capterra;
        private IFileHelper mockFileHelper;
        private IIocContainer mockIocContainer;
        private IParser mockParser;

        public CapterraTests()
        {
            mockFileHelper = A.Fake<IFileHelper>();
            mockIocContainer = A.Fake<IIocContainer>();
            mockParser = A.Fake<IParser>();
            A.CallTo(() => mockIocContainer.ResolveKeyed<IParser>(A<string>._))
                .Returns(mockParser);
            Ioc.Container = mockIocContainer;
        }

        [Fact]
        public void ShouldReturnZeroProductsWhenEmptyFileReceived()
        {
            // Arrange
            A.CallTo(() => mockFileHelper.ReadFileText(A<string>._)).Returns(string.Empty);

            // Act
            capterra = new Capterra(mockFileHelper);
            var output = capterra.ParseInput();

            // Assert
            A.CallTo(() => mockParser.Parse<List<Product>>(A<string>._)).MustHaveHappened();
            Assert.Empty(output.Products);
        }

        [Fact]
        public void ShouldReturnProductsWhenValidFileReceived()
        {
            // Arrange
            A.CallTo(() => mockFileHelper.ReadFileText(A<string>._)).Returns(TestConstants.YamlFileText);
            A.CallTo(() => mockParser.Parse<List<Product>>(A<string>._)).Returns(GetProducts());

            // Act
            capterra = new Capterra(mockFileHelper);
            var output = capterra.ParseInput();

            // Assert
            A.CallTo(() => mockParser.Parse<List<Product>>(A<string>._)).MustHaveHappened();
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
