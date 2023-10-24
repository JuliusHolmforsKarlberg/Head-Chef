using Head_Chef.Models.Interfaces;
using Head;
using Head_Chef.Models.Interfaces;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "6C7A2F4F-31C9-4DEB-90A8-CFFCAA733600",
        GroupName = GroupNames.Specialized,
        DisplayName = "Find",
        Description = "This is a find template"
    )]
    public class FindPage : SitePageData, IHideSitemap
    {
    }
}