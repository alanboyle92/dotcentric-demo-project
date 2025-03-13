using Dotcentric.Website.Models.Blocks;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Pages
{
    [ContentType(DisplayName = "Article Page", GUID = "cd28ffa9-b558-4796-a89e-32f489a0fd9f")]
    public class ArticlePage : SitePageData
    {
        [Display(Name = "Main Content", GroupName = SystemTabNames.Content, Order = 10)]
        [AllowedTypes(typeof(RichTextBlock), typeof(ThreeCardBlock))]
        [UIHint(UIHint.Block)]
        public virtual ContentReference? BlockContent { get; set; }
    }
}
