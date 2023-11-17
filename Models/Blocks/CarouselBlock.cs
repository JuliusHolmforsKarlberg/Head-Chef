using Head_Chef.Models.Pages;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Blocks
{
    [ContentType(
        GUID = "7C4DCD42-5F1E-48F1-A699-C675E1E0CAFF",
        GroupName = GroupNames.Specialized,
        DisplayName = "Carousel Block",
        Description = "This is a carousel block template"
    )]
    public class CarouselBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [AllowedTypes(typeof(CarouselPage))]
        public virtual ContentArea Carousel { get; set; }
    }
}