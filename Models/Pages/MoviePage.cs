using EPiServer.Web;
using Head_Chef.Business.Descriptors;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "D533589C-6756-47FA-8438-4DF110F15C09",
        GroupName = GroupNames.Specialized,
        DisplayName = "Movie",
        Description = "This is a movie template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class MoviePage : SitePageData, ICarouselIcon
    {
        [Display(
            Name = "Poster",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Poster { get; set; } = string.Empty;

        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        public virtual string Title { get; set; } = string.Empty;


        [Display(
            Name = "Plot",
            GroupName = SystemTabNames.Content,
            Order = 25
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string Plot { get; set; } = string.Empty;

        [Display(
            Name = "Year",
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        public virtual string Year { get; set; } = string.Empty;

        [Display(
            Name = "Genre",
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        public virtual string Genre { get; set; } = string.Empty;

        [Display(
            Name = "IMDB rating",
            GroupName = SystemTabNames.Content,
            Order = 50
        )]
        public virtual string ImdbRating { get; set; } = string.Empty;

        [Display(
            Name = "IMDB id",
            GroupName = SystemTabNames.Content,
            Order = 60
        )]
        [Editable(false)]
        public virtual string ImdbID { get; set; } = string.Empty;
    }
}