using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagementSystem.Tests
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsControllerTests(WebApplicationFactory<Program> factory)
        {
           
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateProduct_ReturnsCreatedResponse()
        {
            var product = new Product { Name = "Test Product", Quantity = 10, Price = 100 };
            var response = await _client.PostAsJsonAsync("/api/products", product);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetProductById_ReturnsProduct()
        {
            var response = await _client.GetAsync("/api/products/1");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateProduct_ReturnsNoContentResponse()
        {
            var product = new Product { Id = 1, Name = "Updated Product", Quantity = 5, Price = 50 };
            var response = await _client.PutAsJsonAsync("/api/products/1", product);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNoContentResponse()
        {
            var response = await _client.DeleteAsync("/api/products/1");

            response.EnsureSuccessStatusCode();
        }
    }
}
