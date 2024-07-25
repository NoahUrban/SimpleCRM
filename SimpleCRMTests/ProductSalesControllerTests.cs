using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SimpleCRM.Controllers;
using SimpleCRM.Models;
using Xunit;

namespace SimpleCRM.Tests.Controllers
{
    public class ProductSalesControllerTests
    {
        private readonly Mock<IProductSalesRepository> _mockRepository;
        private readonly ProductSalesController _controller;

        public ProductSalesControllerTests()
        {
            _mockRepository = new Mock<IProductSalesRepository>();
            _controller = new ProductSalesController(_mockRepository.Object, null); 
        }

        [Fact]
        public void Index_ReturnsViewResult_WithAllSales()
        {
            // Arrange
            var expectedSales = new List<ProductSales>
            {
                new ProductSales { OrderNumber = 1, CustomerName = "Customer A" },
                new ProductSales { OrderNumber = 2, CustomerName = "Customer B" },
            };
            _mockRepository.Setup(repo => repo.GetAllSales()).Returns(expectedSales);

            // Act
            var result = _controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<ProductSales>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(expectedSales.Count, model.Count());
        }

        [Fact]
        public void InsertSaleToDatabase_RedirectsToIndexAction()
        {
            // Arrange
            var sale = new ProductSales { OrderNumber = 1, CustomerName = "Test Customer", Status = "Shipped" };

            // Act
            var result = _controller.InsertSaleToDatabase(sale) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
