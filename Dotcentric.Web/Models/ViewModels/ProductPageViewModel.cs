using Dotcentric.Infrastructure.Models;
using Dotcentric.Website.Models.Pages;

namespace Dotcentric.Website.Models.ViewModels
{
    public class ProductPageViewModel : IPageViewModel<ProductPage>
    {
        public ProductPageViewModel(ProductPage productPage)
        {
            CurrentPage = productPage;
        }

        public Product? Product { get; set; }

        public ProductPage CurrentPage { get; set; }
    }
}
