using Xunit;
using Microsoft.EntityFrameworkCore;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Repositories;
using System.Threading.Tasks;
using FluentAssertions;
using technical_tests_backend_ssr.Domain;

namespace technical_tests_backend_ssr.UnitTests.Repositories
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task AddAsync_ShouldAddProductToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TechnicalTestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            await using var context = new TechnicalTestDbContext(options);
            var repository = new ProductRepository(context);

            var product = new Product { Name = "New Product", Price = 20 };

            // Act
            await repository.AddAsync(product);
            await context.SaveChangesAsync();

            // Assert
            var saved = await context.Products.FirstOrDefaultAsync(p => p.Name == "New Product");
            saved.Should().NotBeNull();
            saved.Price.Should().Be(20);
        }
    }
}
