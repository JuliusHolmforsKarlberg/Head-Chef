using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Web;
using Head_Chef.Models.Pages;
using Head_Chef.Business.Extensions;

namespace Head_Chef.Business.ScheduledJobs
{
    [ScheduledPlugIn(
        DisplayName = "Delete Article Pages",
        Description = "This job deletes article pages",
        GUID = "C7CAAA45-12A6-4455-BA4D-38006A8B95AD"
    )]
    public class DeleteArticlePages : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;

        public DeleteArticlePages(IContentLoader contentLoader,
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
            var articlePages = GetArticlePages();
            var status = 0;

            foreach (var item in articlePages)
            {
                _contentRepository.Delete(item.ContentLink, true, EPiServer.Security.AccessLevel.NoAccess);

                status++;
            }

            if (_stopSignaled)
            {
                return "The job has beeen cancelled";
            }

            return $"Article pages deleted: {status}";
        }

        private IEnumerable<ArticlePage> GetArticlePages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var startPage = _contentLoader.Get<StartPage>(contentReference);
            var articlePages = new List<ArticlePage>();

            startPage.GetDescendantsOfType(articlePages);

            return articlePages;
        }
    }
}