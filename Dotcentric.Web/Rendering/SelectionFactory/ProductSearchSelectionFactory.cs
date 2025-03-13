using EPiServer.Shell.ObjectEditing;

namespace Dotcentric.Website.Rendering.SelectionFactory
{
    public class ProductSearchSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>
        {
            new SelectItem { Text = "Search By Price Range", Value = "price" },
            new SelectItem { Text = "Search By CategoryID", Value = "category" },
        };
        }
    }
}
