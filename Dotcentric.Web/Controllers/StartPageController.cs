using Dotcentric.Website.Models.Pages;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}
