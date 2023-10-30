using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Head_Chef.Controllers
{
    [Route("error")]
    public class ErrorPageController : PageController<ErrorPage>
    {
        [Route("404")]
        public IActionResult Index(ErrorPage currentPage)
        {
            var model = new ErrorPageViewModel(currentPage);

            return View(model);
        }
    }
}
