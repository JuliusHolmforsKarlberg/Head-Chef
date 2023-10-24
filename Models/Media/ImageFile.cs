using EPiServer.Framework.DataAnnotations;

namespace Head_Chef.Models.Media
{
    [ContentType(GUID = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,webp")]
    public class ImageFile : ImageData
    {
    }
}