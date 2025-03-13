using Dotcentric.Website.Models.Pages;
using Dotcentric.Website.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        public ActionResult Index(ArticlePage currentPage)
        {
            var model = new PageViewModel<ArticlePage>(currentPage);
            return View(model);
        }
    }
}
