using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class AllArticlesViewModel : PageViewModel<AllArticlesPage>
    {
        public AllArticlesViewModel(AllArticlesPage currentPage) : base(currentPage)
        {            
        }

        public IEnumerable<ArticlePage>? AllArticles { get; set; }
    }
}
