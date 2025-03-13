using Dotcentric.Infrastructure.Service;
using Dotcentric.Website.Models.Pages;
using Dotcentric.Website.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Controllers
{
    public class ProductPageController : PageController<ProductPage>
    {
        private readonly IProductService _productService;

        public ProductPageController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(ProductPage currentPage)
        {
            var viewModel = new ProductPageViewModel(currentPage);

            if (!string.IsNullOrEmpty(currentPage.ProductId))
            {
                viewModel.Product = _productService.GetProductById(currentPage.ProductId).Result;
            }

            return View(viewModel);
        }
    }
}
