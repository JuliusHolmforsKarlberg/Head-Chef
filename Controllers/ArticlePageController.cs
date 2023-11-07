using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class ArticlePageController : PageControllerBase<ArticlePage>
    {
        private readonly IContentLoader _contentLoader;

        public ArticlePageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(ArticlePage currentPage)
        {
            var model = new ArticlePageViewModel(currentPage);
            return View(model);
        }
    }
}
