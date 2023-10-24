using Head_Chef.Models.ViewModels;

namespace Head_Chef.Components.Carousel
{
    public class CarouselViewModel
    {
        public List<CarouselViewPageModel> Pages { get; set; } = new List<CarouselViewPageModel>();
    }
}