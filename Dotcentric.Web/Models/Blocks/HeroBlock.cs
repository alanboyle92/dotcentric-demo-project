using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Blocks
{
    [ContentType(DisplayName = "Hero Block", GUID = "5702f132-40e1-45e4-8ba9-6a2badc914cd",
        Description = "Hero Block to be displayed as header for page")]
    public class HeroBlock : BlockData
    {
        [Display(Name = "Headline", Order = 100)]
        public virtual string? Headline { get; set; }

        [Display(Name = "Description", Order = 200)]
        public virtual string? Description { get; set; }

        [Display(Name = "Image", Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? Image { get; set; }
    }
}
