using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using InventoryManagementSystem.Services;
using Moq;
using Xunit;

namespace InventoryManagementSystem.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var products = new List<Product> { new Product(), new Product() };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            var result = await _service.GetAllProductsAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
        {
            var product = new Product { Id = 1 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.GetProductByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldAddProduct()
        {
            var product = new Product { Id = 1 };
            await _service.CreateProductAsync(product);

            _mockRepo.Verify(repo => repo.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateProduct()
        {
            var product = new Product { Id = 1 };
            await _service.UpdateProductAsync(product);

            _mockRepo.Verify(repo => repo.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldDeleteProduct()
        {
            var product = new Product { Id = 1 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            await _service.DeleteProductAsync(1);

            _mockRepo.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
