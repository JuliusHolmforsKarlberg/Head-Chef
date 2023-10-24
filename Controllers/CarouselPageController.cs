using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class CarouselPageController : PageControllerBase<CarouselPage>
    {
    public IActionResult Index(CarouselPage currentPage)
    {
        //var model = new StartPageViewModel(currentPage);

        return View(currentPage);
    }
}
}