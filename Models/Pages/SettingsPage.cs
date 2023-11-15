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
            Name = "Navigation",
            Description = ""
        )]        
        public virtual ContentArea Navigation { get; set; }

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
            Name = "All Articles",
            Description = "Select the all articles page"
        )]
        public virtual ContentReference AllArticlesPage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30,
            Name = "Recipes",
            Description = "Select the recipes container"
        )]
        public virtual ContentReference RecipesContainer { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40,
            Name = "My Recipes",
            Description = "Select the my recipes page"
        )]
        public virtual ContentReference MyRecipesPage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50,
            Name = "Articles",
            Description = "Select the articles container"
        )]
        public virtual ContentReference ArticleContainer { get; set; }

        [ScaffoldColumn(false)]
        public override CategoryList Category { get; set; }
    }
}