using Dotcentric.Infrastructure.Models;

namespace Dotcentric.Infrastructure.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetCardsByPriceRange(string priceMin, string priceMax);

        Task<List<Product>> GetCardsByCategoryId(string categoryId);
    }
}
