using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;

namespace Head_Chef.Models.ViewModels
{
    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        //public List<MoviesViewModel.Search> Movies { get; set; }

        //public MovieViewModel.Root Movie { get; set; }

        public List<RecipeCardsViewModel.Result> Recipes { get; set; }

        public RecipeViewModel.Root Recipe { get; set; }
    }
}