using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Dotcentric.Website.Controllers
{
    public class BlockController : BlockComponent<BlockData>
    {
        protected override IViewComponentResult InvokeComponent(BlockData currentContent)
        {
            if (currentContent is BlockData blockData)
            {
                return View(blockData.GetOriginalType().Name, blockData);
            }

            return Content("Block type is not recognized.");
        }
    }
}
