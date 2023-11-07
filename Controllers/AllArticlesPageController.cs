using EPiServer.Web;
using Head_Chef.Business.Extensions;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class AllArticlesPageController : PageControllerBase<AllArticlesPage>
    {
        private readonly IContentLoader _contentLoader;

        public AllArticlesPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(AllArticlesPage currentPage)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var settingsPages = new List<SettingsPage>();
            startPage.GetDescendantsOfType(settingsPages);
            var settingsPage = settingsPages.FirstOrDefault();
            var model = new AllArticlesViewModel(currentPage);

            if (settingsPage != null)
            {
                var parent = settingsPage.ArticleContainer;

                if (parent != null)
                {
                    model.AllArticles = _contentLoader.GetChildren<ArticlePage>(parent);
                }
            }

            return View(model);
        }
    }
}
