using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Pages
{
    [ContentType(DisplayName = "Home Page", GUID = "79dbfd76-d224-4a46-97e5-fd772ef59192")]
    public class StartPage : SitePageData
    {
        [Display(Name = "Main content area", GroupName = SystemTabNames.Content, Order = 100)]
        public virtual ContentArea? MainContentArea { get; set; }
    }
}
