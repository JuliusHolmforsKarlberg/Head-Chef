using EPiServer.Web.Mvc;
using Head_Chef.Components.Carousel;
using Head_Chef.Models.Blocks;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Components.Blocks
{
    public class ContactBlockComponent : AsyncBlockComponent<CarouselBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(CarouselBlock currentContent)
        {
            var model = new CarouselBlockViewModel();
            var i = 0;
            var ii = 1;

            foreach (var item in currentContent.Carousel.FilteredItems.Select(x => x.LoadContent()))
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

            return await Task.FromResult(View("~/components/blocks/default.cshtml", model));
        }
    }
}