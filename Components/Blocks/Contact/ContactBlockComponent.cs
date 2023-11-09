using EPiServer.Web.Mvc;

using Head_Chef.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Components.Blocks.Contact
{
    public class ContactBlockComponent : AsyncBlockComponent<ContactBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(ContactBlock currentContent)
        {
            var model = new ContactBlockViewModel();


            return await Task.FromResult(View("~/Components/Blocks/Contact/Default.cshtml", model));
        }
    }
}

