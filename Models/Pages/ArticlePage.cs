﻿using EPiServer.Web;
using Head_Chef.Models.Pages;
using System.ComponentModel.DataAnnotations;
using static Head_Chef.Globals;

namespace Head_Chef.Models.Pages
{
    [ContentType(
        GUID = "7531CE46-4964-4884-AB1F-E0FC74E9192D",
        GroupName = GroupNames.Specialized,
        DisplayName = "Article",
        Description = "This is an article template"
    )]
    public class ArticlePage : SitePageData
    {
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            Name = "Body",
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [UIHint(UIHint.Textarea)]
        public virtual XhtmlString Body { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }
    }
}