using EPiServer.Shell.Web.Mvc;
using Head_Chef.Controllers;
using Head_Chef.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Models.ViewModels
{
    public class CookiesPageViewModel : PageViewModel<CookiesPage>
    {
        public CookiesPageViewModel(CookiesPage currentPage) : base(currentPage)
        {
        }
    }
}