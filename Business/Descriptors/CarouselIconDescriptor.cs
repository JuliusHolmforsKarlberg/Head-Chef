using EPiServer.Shell;
using Head_Chef;

namespace Head_Chef.Business.Descriptors
{
    [UIDescriptorRegistration]
    public class CarouselIconDescriptor : UIDescriptor<ICarouselIcon>
    {
        public CarouselIconDescriptor()
        {
            IconClass = ContentIcons.ObjectIcons.Video;
        }
    }

    public interface ICarouselIcon
    {
    }
}