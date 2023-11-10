using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class ContactPageController : PageControllerBase<ContactPage>
{
        private readonly IContentLoader _contentLoader;

        public ContactPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(ContactPage currentPage)
        {
            var model = new ContactPageViewModel(currentPage);
            return View(model);
        }
    }
}
