using Dotcentric.Website.Models.Pages;

namespace Dotcentric.Website.Models.ViewModels
{
    public interface IPageViewModel<T> where T : SitePageData
    {
        T CurrentPage { get; }
    }
}
