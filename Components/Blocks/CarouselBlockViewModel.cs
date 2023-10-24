using Head_Chef.Models.ViewModels;

namespace Head_Chef.Components.Carousel
{
    public class CarouselBlockViewModel
    {
        public List<CarouselViewPageModel> Pages { get; set; } = new List<CarouselViewPageModel>();
    }
}