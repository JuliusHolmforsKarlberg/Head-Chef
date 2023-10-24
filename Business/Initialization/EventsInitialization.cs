using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using Head_Chef.Models.Pages;

namespace Head_Chef.Business.Initialization
{
    [InitializableModule]
    public class EventsInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var events = context.Locate.ContentEvents();
            events.PublishingContent += PublishingContent;
        }

        private void PublishingContent(object sender, ContentEventArgs e)
        {
            var page = e.Content as SitePageData;

            if (page != null)
            {
                page.XmlSitemapDate = DateTime.Now.ToString("d", Thread.CurrentThread.CurrentCulture);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}