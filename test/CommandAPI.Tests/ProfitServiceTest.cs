using System;
using CommandAPI.Models;
using CommandAPI.Services;
using Xunit;

namespace CommandAPI.Tests
{
    public class ProfitServiceTest
    {
        private readonly IProfitService _profitService;

        public ProfitServiceTest()
        {
            _profitService = new ProfitService();
        }

        [Fact]
        public void CalculateNetMargin_WhenNumberOfProductsIsLessThan50_ReturnsCorrectNetMargin()
        {
            // Arrange
            int numberOfProducts = 49;
            double sellingPrice = 10.0;
            double expectedNetMargin = 377.0;

            // Act
            var profit = _profitService.CalculateNetMargin(numberOfProducts, sellingPrice);

            // Assert
            Assert.Equal(expectedNetMargin, profit.NetMargin);
        }

        [Fact]
        public void CalculateNetMargin_WhenNumberOfProductsIsMoreThan50_ReturnsCorrectNetMargin()
        {
            // Arrange
            int numberOfProducts = 51;
            double sellingPrice = 10.0;
            double expectedNetMargin = 443.8;

            // Act
            var profit = _profitService.CalculateNetMargin(numberOfProducts, sellingPrice);

            // Assert
            Assert.Equal(expectedNetMargin, profit.NetMargin);
        }
    }
}