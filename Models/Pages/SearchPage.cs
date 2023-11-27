using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "C6324D3E-F016-404C-A86A-88B945508C64",
        GroupName = GroupNames.Specialized,
        DisplayName = "Search",
        Description = "This is a search template"
    )]
    public class SearchPage : SitePageData
    {

        [Display(
            Name = "Search page text",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [UIHint(UIHint.Textarea)]
        [CultureSpecific]
        public virtual XhtmlString SearchPageText { get; set; }
    }
}