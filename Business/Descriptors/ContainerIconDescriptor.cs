using EPiServer.Shell;
using Head_Chef;

namespace Head_Chef.Business.Descriptors
{
    [UIDescriptorRegistration]
    public class ContainerIconDescriptor : UIDescriptor<IContainerIcon>
    {
        public ContainerIconDescriptor()
        {
            IconClass = ContentIcons.ObjectIcons.Container;
        }
    }

    public interface IContainerIcon
    {
    }
}