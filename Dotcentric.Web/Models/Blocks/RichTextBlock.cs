using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Blocks
{
    [ContentType(DisplayName = "Rich Text Block", GUID = "2f934d88-2392-4bf9-b1b3-19313642b51f")]
    public class RichTextBlock : BlockData
    {
        [Display(Name = "Text Area")]
        public virtual XhtmlString? RichText { get; set; }
    }
}
