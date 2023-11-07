using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class ArticlePageViewModel : PageViewModel<ArticlePage>
    {
        public ArticlePageViewModel(ArticlePage currentPage) : base(currentPage)
        {            
        }

        public string Heading { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        //public ArticlePage Page { get; set; }

    }
}
