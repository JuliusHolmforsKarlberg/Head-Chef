using EPiServer.Web;
using Head_Chef.Business.Extensions;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class MyRecipesPageController : PageControllerBase<MyRecipesPage>
    {
        private readonly IContentLoader _contentLoader;

        public MyRecipesPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(MyRecipesPage currentPage)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var settingsPages = new List<SettingsPage>();
            startPage.GetDescendantsOfType(settingsPages);
            var settingsPage = settingsPages.FirstOrDefault();
            var model = new MyRecipesViewModel(currentPage);

            if (settingsPage != null)
            {
                var parent = settingsPage.RecipesContainer;

                if (parent != null)
                {
                    model.MyRecipes = _contentLoader.GetChildren<RecipePage>(parent);
                }
            }

            return View(model);
        }
    }
}
