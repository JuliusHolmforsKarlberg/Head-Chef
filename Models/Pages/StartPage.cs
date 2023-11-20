using Head_Chef.Business.Enums;
using Head_Chef.Models.Blocks;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "2B81E893-1E14-4B4E-B9EC-FEAD0F29ABDD",
        GroupName = GroupNames.Specialized,
        DisplayName = "Start",
        Description = "This is a start template"
    )]
    [AvailableContentTypes(Availability.Specific,
        Include = new[]
        {
            typeof(SettingsPage),
            typeof(ContainerPage),
            typeof(SearchPage),
            typeof(FindPage),
            typeof(ErrorPage),
            typeof(FormsPage),
            typeof(MyRecipesPage),
            typeof(AllArticlesPage),
            typeof(ContactPage)
        }
    )]
    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10,
            Name = "Carousel",
            Description = ""
        )]
        [AllowedTypes(typeof(CarouselPage), typeof(CarouselBlock))]
        public virtual ContentArea Carousel { get; set; }

        [ScaffoldColumn(false)]
        public override CategoryList Category { get; set; }
    }
}