using Head_Chef.Models.Pages;
using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class CarouselViewPageModel
    {
        public string Active { get; set; }

        public string AriaCurrent { get; set; }

        public int DataBsSlideTo { get; set; }

        public string AriaLabel { get; set; }

        public CarouselPage Page { get; set; }
    }
}