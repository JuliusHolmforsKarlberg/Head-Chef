using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 10
        )]        
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle =this.GetPropertyValue(p => p.MetaTitle);
                return !string.IsNullOrEmpty(metaTitle) ? metaTitle : PageName;
            }

            set => this.SetPropertyValue(p => p.MetaTitle, value);
        }

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 15
        )]
        [Editable(false)]
        [CultureSpecific]
        //ta bort, men kolla om hela filen EventsInitialization.cs kan tas bort
        public virtual string XmlSitemapDate { get; set; }

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 20
        )]
        [CultureSpecific]       
        public virtual string MetaDescription { get; set; } = string.Empty;
    }
}