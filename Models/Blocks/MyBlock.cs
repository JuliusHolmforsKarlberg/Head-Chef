using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Head_Chef.Templates.Alloy.Models.Blocks
{
    [ContentType(DisplayName = "MyBlock", Description = "")]
    public class MyBlock : BlockData
    {

        [UIHint(UIHint.Image)]
        [Display(
            Name = "Image Url",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual Url ImageUrl { get; set; }


        [Display(
            Name = "Image Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string ImageDescription { get; set; }
    }
}