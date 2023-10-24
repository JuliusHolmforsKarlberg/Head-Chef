using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Web;
using Head_Chef.Models.Pages;
using Head_Chef.Business.Extensions;

namespace Head_Chef.Business.ScheduledJobs
{
    [ScheduledPlugIn(
        DisplayName = "Delete Unpublished Carousel Pages",
        Description = "This job deletes unpublished carousel pages",
        GUID = "DA7B79E7-A6B1-4025-B6DC-AF7DB550EABB"
    )]
    public class DeleteUnpublishedCarouselPages : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;

        public DeleteUnpublishedCarouselPages(IContentLoader contentLoader,
            ISiteDefinitionRepository siteDefinitionRepository, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;
            _siteDefinitionRepository = siteDefinitionRepository;
            _contentRepository = contentRepository;

            IsStoppable = true;
        }

        public override void Stop()
        {
            _stopSignaled = true;
        }

        public override string Execute()
        {
            var carouselPages = GetCarouselPages();
            var status = 0;

            foreach (var item in carouselPages)
            {
                if (item.StopPublish != null)
                {
                    _contentRepository.Delete(item.ContentLink, true, EPiServer.Security.AccessLevel.NoAccess);

                    status++;
                }
            }

            if (_stopSignaled)
            {
                return "The job has beeen cancelled";
            }

            return $"Unpublished carousel pages deleted: {status}";
        }

        private IEnumerable<CarouselPage> GetCarouselPages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var startPage = _contentLoader.Get<StartPage>(contentReference);
            var carouselPages = new List<CarouselPage>();

            startPage.GetDescendantsOfType(carouselPages);

            return carouselPages;
        }
    }
}