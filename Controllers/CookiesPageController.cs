using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class CookiesPageController : PageControllerBase<CookiesPage>
    {
        public IActionResult Index(CookiesPage currentContent)
        {
            var model = new CookiesPageViewModel(currentContent);
            return View(model);

        }
    }
}