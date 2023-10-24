using Head_Chef.Models.Pages;

namespace Head_Chef.Business.Services.Interfaces
{
    public interface IXmlSitemapService
    {
        IEnumerable<SitePageData> Descendants(XmlSitemap currentPage);
    }
}