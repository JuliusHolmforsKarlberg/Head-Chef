using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "BAF18E33-100E-46D6-83F4-BE28907DCCE2",
        GroupName = GroupNames.Specialized,
        DisplayName = "Contact",
        Description = "This is a contact template"
    )]
    public class ContactPage : SitePageData
    {
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10,
           Name = "Contact",
           Description = ""
       )]
        [AllowedTypes(typeof(ContactBlock))]
        public virtual ContentArea? ContactArea { get; set; }

    }
}