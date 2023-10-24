using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using EPiServer.Initialization;
using Head_Chef.Models.Pages;
using EPiServer.ServiceLocation;

namespace Head_Chef.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(
        typeof(CmsCoreInitialization)
    )]
    public class RootPageInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentTypeRepository = context.Locate.Advanced.GetInstance<IContentTypeRepository>();
            var sysRoot = contentTypeRepository.Load("SysRoot") as PageType;
            var setting = new AvailableSetting { Availability = Availability.Specific };

            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load<StartPage>().Name);

            var availableSettingsRepository = context.Locate.Advanced.GetInstance<IAvailableSettingsRepository>();
            availableSettingsRepository.RegisterSetting(sysRoot, setting);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}