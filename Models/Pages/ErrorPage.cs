using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "CA0A7B12-C83E-4571-9DAD-E9933B2E761E"
    )]
    public class ErrorPage : SitePageData
    {
        [Display( 
            GroupName = SystemTabNames.Content,
            Order = 10
            )]
        [CultureSpecific]
        public virtual string Header { get; set; }   
    }
}