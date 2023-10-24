using EPiServer.Find;
using EPiServer.Find.Framework;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    //[TemplateDescriptor(Default = true)]
    public class FindPageController : PageController<FindPage>
{
    public ActionResult Index(FindPage currentPage, string q)
    {
        var model = new FindPageViewModel(currentPage, q);

        if (string.IsNullOrEmpty(q))
        {
            return View(model);
        }

        var unifiedSearch = SearchClient.Instance.UnifiedSearchFor(q);
        model.Results = unifiedSearch.GetResult();

        return View(model);
    }
}
}
