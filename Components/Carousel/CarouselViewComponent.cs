using EPiServer.Web;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Components.Carousel
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly IContentLoader _contentLoader;

        public CarouselViewComponent(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IViewComponentResult Invoke()
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
            var model = new ContactViewModel();
            var i = 0;
            var ii = 1;

            foreach (var item in startPage.Carousel.FilteredItems.Select(x => x.LoadContent()))
            {
                if (item is CarouselPage)
                {
                    var page = new CarouselViewPageModel();

                    if (i == 0)
                    {
                        page.Active = "active";
                        page.AriaCurrent = "true";
                    }
                    else
                    {
                        page.Active = null;
                        page.AriaCurrent = null;
                    }

                    page.DataBsSlideTo = i++;
                    page.AriaLabel = string.Format("Slide {0}", ii++);
                    page.Page = item as CarouselPage;

                    model.Pages.Add(page);
                }
            }

            return View("~/components/carousel/default.cshtml", model);
        }
    }
}