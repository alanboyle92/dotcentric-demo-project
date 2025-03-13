using Dotcentric.Infrastructure.Models;
using Dotcentric.Infrastructure.Service;
using System.Text.Json;

namespace Dotcentric.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetCardsByCategoryId(string categoryId)
        {
            var response = await _httpClient.GetAsync($"https://api.escuelajs.co/api/v1/products/?categoryId={categoryId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

                return products.Take(3).ToList();
            }

            return new List<Product>();
        }

        public async Task<List<Product>> GetCardsByPriceRange(string priceMin, string priceMax)
        {
            var response = await _httpClient.GetAsync($"https://api.escuelajs.co/api/v1/products/?price_min={priceMin}&price_max={priceMax}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

                return products?.Take(3).ToList();
            }

            return new List<Product>();
        }
    }
}
