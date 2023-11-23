using EPiServer.Web;
using Head_Chef.Business.Descriptors;
using Head_Chef.Business.Descriptors;
using Head_Chef.Models.Pages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "F7D0B456-B965-422C-8153-EF4DE77C24C9",
        GroupName = GroupNames.Specialized,
        DisplayName = "FormsPage",
        Description = "This is a Forms template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class FormsPage : SitePageData, ICarouselIcon
    {
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Title { get; set; } = string.Empty;

        [Display(
            Name = "Email",
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        public virtual string Email { get; set; } = string.Empty;

        [Display(
        GroupName = SystemTabNames.Content,
        Order = 30
        )]
        public virtual ContentArea ContentArea { get; set; }

    }
      
}