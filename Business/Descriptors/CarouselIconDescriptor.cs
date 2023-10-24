using EPiServer.Shell;
using Head;

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