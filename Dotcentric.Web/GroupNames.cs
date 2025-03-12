using System.ComponentModel.DataAnnotations;

namespace Dotcentric.Website
{
    public class GroupNames
    {
        [GroupDefinitions]
        public static class TabNames
        {
            [Display(Order = 20)]
            public const string MetaData = "Meta Data";
        }
    }
}
