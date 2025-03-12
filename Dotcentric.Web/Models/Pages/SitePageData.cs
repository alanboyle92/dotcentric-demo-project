using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Pages
{
    public abstract class SitePageData : PageData
    {
        public virtual MetaData? MetaData => new MetaData
        {
            MetaTags = new MetaTags
            {
                MetaTitle = !string.IsNullOrEmpty(MetaTitle) ? MetaTitle : PageName,
                MetaDescription = MetaDescription
            }
        };

        [Display(Name = "Meta Title", GroupName = GroupNames.TabNames.MetaData, Order = 100)]
        public virtual string? MetaTitle { get; set; }

        [Display(Name = "Meta Description", GroupName = GroupNames.TabNames.MetaData, Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string? MetaDescription { get; set; }

        [Display(Name = "Is Error Page", GroupName = SystemTabNames.Settings, Order = 100)]
        public virtual bool IsErrorPage { get; set; }
    }
}
