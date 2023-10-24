using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Web;
using Head_Chef.Models.Pages;
using Head_Chef.Business.Extensions;

namespace Head_Chef.Business.ScheduledJobs
{
    [ScheduledPlugIn(
        DisplayName = "Delete Movie Pages",
        Description = "This job deletes movie pages",
        GUID = "A29ED108-1813-4153-9931-E109FF235307"
    )]
    public class DeleteMoviePages : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;

        public DeleteMoviePages(IContentLoader contentLoader,
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
            var moviePages = GetMoviePages();
            var status = 0;

            foreach (var item in moviePages)
            {
                _contentRepository.Delete(item.ContentLink, true, EPiServer.Security.AccessLevel.NoAccess);

                status++;
            }

            if (_stopSignaled)
            {
                return "The job has beeen cancelled";
            }

            return $"Movie pages deleted: {status}";
        }

        private IEnumerable<MoviePage> GetMoviePages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var startPage = _contentLoader.Get<StartPage>(contentReference);
            var moviePages = new List<MoviePage>();

            startPage.GetDescendantsOfType(moviePages);

            return moviePages;
        }
    }
}