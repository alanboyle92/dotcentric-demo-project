using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dotcentric.Website.Rendering
{
    public static class HtmlHelpers
    {
        public static void RenderContent(this IHtmlHelper html, ContentReference contentLink)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            IContentData contentData;

            if (contentLoader.TryGet(contentLink, out contentData))
            {
                html.RenderContentData(contentData, true);
            }
        }
    }
}
