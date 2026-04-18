using NorthWindCatalog.Services.DTOs;

namespace NorthWindCatalog.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var product = new ProductDto
            {
                UnitPrice = 10,
                UnitsInStock = 5
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(50, result);
        }
    }
}
