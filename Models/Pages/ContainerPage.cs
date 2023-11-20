using Head_Chef.Business.Descriptors;
using Head_Chef.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "69232325-FD94-4F3D-8E58-186A174B095A",
        GroupName = Globals.GroupNames.Specialized,
        DisplayName = "Container"
    )]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[]
        {
            typeof(CarouselPage),
            //typeof(MoviePage),
            typeof(RecipePage),
            typeof(ArticlePage)
        }
    )]
    public class ContainerPage : PageData, IContainerIcon
    {
        [ScaffoldColumn(false)]
        public override CategoryList Category { get; set; }
    }
}