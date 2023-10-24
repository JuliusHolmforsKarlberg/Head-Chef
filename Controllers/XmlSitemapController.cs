using Head_Chef.Business.Services.Interfaces;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Head_Chef.Controllers
{
    public class XmlSitemapController : PageControllerBase<XmlSitemap>
{
    private IXmlSitemapService _xmlSitemapService;

    public XmlSitemapController(IXmlSitemapService xmlSitemapService)
    {
        _xmlSitemapService = xmlSitemapService;
    }

    public ActionResult Index(XmlSitemap currentPage)
    {
        var model = new XmlSitemapViewModel(currentPage)
        {
            Descendants = _xmlSitemapService.Descendants(currentPage)
        };

        return View(model);
    }
}
}
