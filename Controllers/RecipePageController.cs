using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{

    public class RecipePageController : PageControllerBase<RecipePage>
    {
        private readonly IContentLoader _contentLoader;

        public RecipePageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(RecipePage currentPage)
        {
            var model = new RecipePageViewModel(currentPage);

            return View(model);
        }

    }
}
