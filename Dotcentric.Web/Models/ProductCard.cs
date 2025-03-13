using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models
{
    public class ProductCard
    {
        [Display(Name = "Product Name")]
        public virtual string? ProductName { get; set; }

        [Display(Name = "Product Description")]
        public virtual string? ProductDescription { get; set; }

        [Display(Name = "Product Image")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ProductImage { get; set; }
    }
}
