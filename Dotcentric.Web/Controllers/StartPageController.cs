using Dotcentric.Website.Models.Pages;
using Dotcentric.Website.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = new PageViewModel<StartPage>(currentPage);
            return View(model);
        }
    }
}
