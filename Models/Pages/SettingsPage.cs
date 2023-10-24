using Head_Chef.Business.Descriptors;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "32526CA9-D56E-4AF9-B43A-1092A395174F",
        GroupName = GroupNames.Specialized,
        DisplayName = "Settings",
        Description = "This is a settings template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class SettingsPage : SitePageData, ISettingsIcon
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10,
            Name = "Search",
            Description = "Select the search page"
        )]
        public virtual ContentReference SearchPage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20,
            Name = "Movies",
            Description = "Select the movies container"
        )]
        public virtual ContentReference MoviesContainer { get; set; }

        [ScaffoldColumn(false)]
        public override CategoryList Category { get; set; }
    }
}