using EPiServer.Find.UnifiedSearch;
using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public class FindPageViewModel : PageViewModel<FindPage>
    {
        public FindPageViewModel(FindPage currentPage, string searchQuery) : base(currentPage)
        {
            SearchQuery = searchQuery;
        }

        public string SearchQuery { get; set; }

        public UnifiedSearchResults Results { get; set; }
    }
}