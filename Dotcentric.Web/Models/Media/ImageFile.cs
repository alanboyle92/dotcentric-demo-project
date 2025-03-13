using EPiServer.Framework.DataAnnotations;

namespace Dotcentric.Website.Models.Media
{
    [ContentType(GUID = "8ae4a1d0-2020-495f-a956-7148e2fb6507")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
    }
}
