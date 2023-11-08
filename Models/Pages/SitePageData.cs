using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Models.Pages
{
    public class SitePageData : PageData
    {

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
            Order = 10
        )]
        [Editable(false)]
        [CultureSpecific]
        public virtual string XmlSitemapDate { get; set; }

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 20,
            Name = "Meta description",
            Description = "Add a description for the page"
        )]
        [CultureSpecific]       
        public virtual string MetaDescription { get; set; } = string.Empty;
    }
}