using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Infrastructure.Business.Validation
{
    public class MaxItemsInListAttribute : ValidationAttribute
    {
        private readonly int _maxItems;

        public MaxItemsInListAttribute(int maxItems)
        {
            _maxItems = maxItems;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null && list.Count > _maxItems)
            {
                ErrorMessage = $"You can only add up to {_maxItems} items.";
                return false;
            }
            return true;
        }
    }
}
