using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{

    [ContentType(
        GUID = "8DFAB13C-4DA2-4309-983D-DE4AE4345B8C",
        GroupName = GroupNames.Specialized,
        DisplayName = "Recipe",
        Description = "This is a recipe template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class RecipePage : SitePageData
    {
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Title { get; set; } = string.Empty;

        [Display(
            Name = "Image",
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        public virtual string Image { get; set; } = string.Empty;

        [Display(
            Name = "Summary",
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string Summary { get; set; } = string.Empty;

        [Display(
            Name = "Instructions",
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string Instructions { get; set; } = string.Empty;

        [Display(
            Name = "Ingredients",
            GroupName = SystemTabNames.Content,
            Order = 50
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string Ingredients { get; set; } = string.Empty;

        [Display(
            Name = "Time until ready",
            GroupName = SystemTabNames.Content,
            Order = 60
        )]
        public virtual int ReadyInMinutes { get; set; }

        [Display(
            Name = "Source url",
            GroupName = SystemTabNames.Content,
            Order = 70
        )]
        public virtual string SpoonacularSourceUrl { get; set; } = string.Empty;

        [Display(
            Name = "Id on Spoontacular",
            GroupName = SystemTabNames.Content,
            Order = 80
        )]
        [Editable(false)]
        public virtual int Id { get; set; }
    }
}
