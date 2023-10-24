using Head_Chef.Models.Pages;

namespace Head_Chef.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }

        LayoutModel Layout { get; set; }

        IContent Section { get; }
    }
}