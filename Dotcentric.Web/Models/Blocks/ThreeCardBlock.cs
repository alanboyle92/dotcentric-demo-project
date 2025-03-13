using Dotcentric.Infrastructure.Business.Validation;
using Dotcentric.Website.Rendering.SelectionFactory;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website.Models.Blocks
{
    [ContentType(DisplayName = "Three Card Block", GUID = "c718fe84-7056-4ba2-9e42-170c7e8a940d",
        Description = "Displays three product cards either manual or from api")]
    public class ThreeCardBlock : BlockData
    {
        [Display(Name = "Product Cards")]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<ProductCard>))]
        [MaxItemsInList(3)]
        public virtual IList<ProductCard>? ProductCards { get; set; }

        [Display(Name = "Price Min")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Please enter a valid number.")]
        public virtual string? PriceMin { get; set; }

        [Display(Name = "Price Max")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Please enter a valid number.")]
        public virtual string? PriceMax { get; set; }

        [Display(Name = "Category ID")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Please enter a valid number.")]
        public virtual string? CategoryID { get; set; }

        [Display(Name = "Select an option")]
        [SelectOne(SelectionFactoryType = typeof(ProductSearchSelectionFactory))]
        public virtual string? SearchSelection { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            SearchSelection = "price";
        }
    }
}
