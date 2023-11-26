using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "50C80BDB-D489-4049-AE66-95DF19C5B79D"
    )]
    public class ThankYouPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
            )]
        [CultureSpecific]
        public virtual string? Header { get; set; }
    }
}