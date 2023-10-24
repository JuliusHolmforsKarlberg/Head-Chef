using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Head_Chef.Business.Descriptors;
using Head;
using Head_Chef.Business.Descriptors;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "D348DDAC-7725-4411-8904-BBFB46BAA6F4",
        GroupName = GroupNames.Specialized,
        DisplayName = "Carousel",
        Description = "This is a carousel template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class CarouselPage : SitePageData, ICarouselIcon
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [Required(AllowEmptyStrings = false)]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [CultureSpecific]
        public virtual XhtmlString Text { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        [CultureSpecific]
        public virtual LinkItem Link { get; set; }
    }
}