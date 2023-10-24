using Head_Chef.Models.Pages;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;

namespace Head_Chef.Models.ViewModels
{
    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
    {
        public IEnumerable<SitePageData> Descendants { get; set; }

        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
        {
        }
    }
}