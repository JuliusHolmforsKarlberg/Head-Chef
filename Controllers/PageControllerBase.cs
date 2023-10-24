using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;

namespace Head_Chef.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
{
}
}
