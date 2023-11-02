using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class StartPageViewModel : PageViewModel<StartPage>
    {
        public StartPageViewModel(StartPage currentPage) : base(currentPage)
        {
        }

        public IEnumerable<RecipePage>? Recipes { get; set; } 
    }
}