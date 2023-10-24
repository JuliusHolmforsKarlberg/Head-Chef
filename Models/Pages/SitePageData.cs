using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 10
        )]
        [Editable(false)]
        [CultureSpecific]
        public virtual string XmlSitemapDate { get; set; }
    }
}