using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "F95C4BE5-CABB-4C51-9570-4D843D95EFD5"
    )]
    public class CookiesPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
            )]
        [CultureSpecific]
        public virtual string? Header { get; set; }
    }
}