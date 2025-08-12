using Xunit;
using Moq;
using FluentAssertions;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Repositories;
using technical_tests_backend_ssr.Services;
using System.Threading.Tasks;

namespace technical_tests_backend_ssr.UnitTests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenExists()
        {
            // Arrange
            var productId = 1;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(productId))
                    .ReturnsAsync(new Product { Id = productId, Name = "Test Product", Price = 10 });

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.GetByIdAsync(productId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(productId);
            result.Name.Should().Be("Test Product");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Product)null);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.GetByIdAsync(99);

            // Assert
            result.Should().BeNull();
        }
    }
}
