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
            Order = 10,
            Name = "Header",
           Description = "Error header"
            )]
        [CultureSpecific]
        public virtual string? Header { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20,
            Name = "Error text",
            Description = "The error text"
            )]
        [CultureSpecific]
        public virtual string? Text { get; set; }
    }
}