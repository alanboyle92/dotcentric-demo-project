using Dotcentric.Infrastructure.Models;
using Dotcentric.Infrastructure.Service;
using Dotcentric.Website.Models.Blocks;
using Dotcentric.Website.Models.ViewModels;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Components
{
    public class ThreeCardBlockViewComponent : BlockComponent<ThreeCardBlock>
    {
        private readonly IProductService _productService;
        private readonly UrlResolver _urlResolver;

        public ThreeCardBlockViewComponent(IProductService productService, UrlResolver urlResolver)
        {
            _productService = productService;
            _urlResolver = urlResolver;
        }

        protected override IViewComponentResult InvokeComponent(ThreeCardBlock currentBlock)
        {
            var viewModel = new ThreeCardBlockViewModel
            {
                Products = new List<Product>()
            };

            if (currentBlock.ProductCards != null && currentBlock.ProductCards.Any())
            {
                foreach (var card in currentBlock.ProductCards)
                {
                    var product = new Product
                    {
                        Title = card.ProductName,
                        Description = card.ProductDescription,
                        Image = _urlResolver.GetUrl(card.ProductImage)
                    };

                    viewModel.Products.Add(product);
                }
            }
            else if (currentBlock.SearchSelection == "price" && (currentBlock.PriceMin != null && currentBlock.PriceMax != null))
            {
                viewModel.Products = _productService
                    .GetCardsByPriceRange(currentBlock.PriceMin, currentBlock.PriceMax)
                    .GetAwaiter().GetResult();
            }
            else if (currentBlock.CategoryID != null)
            {
                viewModel.Products = _productService
                    .GetCardsByCategoryId(currentBlock.CategoryID)
                    .GetAwaiter().GetResult();
            }

            return View(viewModel);
        }

    }
}
