using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class ThankYouPageController : PageControllerBase<ThankYouPage>
    {
        public IActionResult Index(ThankYouPage currentContent)
        {
            var model = new ThankYouPageViewModel(currentContent);
            return View(model);

        }
    }
}