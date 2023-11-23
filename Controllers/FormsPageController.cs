using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class FormsPageController : PageControllerBase<FormsPage>
    {
        public IActionResult Index(FormsPage currentContent)
        {
            var model = new FormsPageViewModel(currentContent);
            return View(model);

        }
    }
}
