using Dotcentric.Website.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Pages
{
    [ContentType(DisplayName = "Product Page", GUID = "dc934794-9135-4965-a189-51468e5d4423", 
        Description = "Product page to display products retrieved from api")]
    public class ProductPage : SitePageData
    {
        [Display(Name = "Product Id", GroupName = SystemTabNames.Content, Order = 10)]
        [Required]
        public virtual string? ProductId { get; set; }

        [Display(Name = "Recommendations", GroupName = SystemTabNames.Content, Order = 20)]
        [AllowedTypes(typeof(ThreeCardBlock))]
        public virtual ContentArea? ProductRecommendations { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            ProductId = "19";
        }
    }
}
