using Head_Chef.Models.Pages;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;

namespace Head_Chef.Models.ViewModels
{
    public class MoviePageViewModel : PageViewModel<MoviePage>
    {
        public MoviePageViewModel(MoviePage currentPage) : base(currentPage)
        {
        }
    }
}