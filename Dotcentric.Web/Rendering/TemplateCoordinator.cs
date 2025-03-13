using Dotcentric.Website.Models.Blocks;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

namespace Dotcentric.Website.Rendering
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {

        public const string BlockFolder = "~/Views/Shared/Blocks/";


        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(HeroBlock), new TemplateModel
            {
                Name = "HeroBlock",
                AvailableWithoutTag = true,
                TemplateTypeCategory = TemplateTypeCategories.MvcPartialView,
                Path = BlockPath("HeroBlock.cshtml")
            });
        }

        private static string BlockPath(string fileName)
        {
            return string.Format("{0}{1}", BlockFolder, fileName);
        }
    }
}
