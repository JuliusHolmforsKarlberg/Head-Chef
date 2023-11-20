using EPiServer.Core.Internal;
using EPiServer.Web;
using Head_Chef.Business.Extensions;
using Head_Chef.Business.Services.Interfaces;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.DDS;

namespace Head_Chef.Controllers
{

    public class RecipePageController : PageControllerBase<RecipePage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICommentService _commentService;
        private readonly IContentRepository _contentRepository; 


        public RecipePageController(IContentLoader contentLoader, ICommentService commentService, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;  //används inte
            _commentService = commentService;
            _contentRepository = contentRepository;  //används inte
        }

        [HttpGet]
        public IActionResult Index(RecipePage currentPage)
        {
            var model = new RecipePageViewModel(currentPage);
            var comments = _commentService.GetCommentsByPage(currentPage.Id);

            model.Comments = comments;      


            return View(model);
        }

        [HttpPost]
        public ActionResult PostComment(string commentText, int pageId)
        {            
            var newComment = new Comment
            {
                PageId = pageId,
                Text = commentText 
            };

            _commentService.Save(newComment);

            return RedirectToAction("Index");

        } 
    }
}
