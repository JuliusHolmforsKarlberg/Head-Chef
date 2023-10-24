using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using EPiServer.ServiceLocation;
using Head_Chef.Business.Extenders;
using Head_Chef.Business.Extenders;

namespace Head_Chef.Business.Initialization
{
    [ModuleDependency(
        typeof(InitializationModule)
    )]
    public class MetaDataInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                var registry = context.Locate.Advanced.GetInstance<MetadataHandlerRegistry>();
                registry.RegisterMetadataHandler(typeof(ContentData), new MetaDataExtender());
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}