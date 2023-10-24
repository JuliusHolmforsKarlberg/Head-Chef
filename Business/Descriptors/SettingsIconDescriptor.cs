using EPiServer.Shell;
using Head_Chef;

namespace Head_Chef.Business.Descriptors
{
    [UIDescriptorRegistration]
    public class SettingsIconDescriptor : UIDescriptor<ISettingsIcon>
    {
        public SettingsIconDescriptor()
        {
            IconClass = ContentIcons.ActionIcons.Settings;
        }
    }

    public interface ISettingsIcon
    {
    }
}