using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class MyRecipesViewModel : PageViewModel<MyRecipesPage>
    {
        public MyRecipesViewModel(MyRecipesPage currentPage) : base(currentPage)
        {            
        }

        public IEnumerable<RecipePage>? MyRecipes { get; set; }
    }
}
