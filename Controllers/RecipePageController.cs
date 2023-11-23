using EPiServer.Core.Internal;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using Head_Chef.Business;
using Head_Chef.Business.Extensions;
using Head_Chef.Business.Services.Interfaces;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Models.DDS;

namespace Head_Chef.Controllers
{

    public class RecipePageController : PageControllerBase<RecipePage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICommentService _commentService;
        private readonly IContentRepository _contentRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RecipePageController> _logger;


        public RecipePageController(IContentLoader contentLoader, ICommentService commentService, IContentRepository contentRepository, IServiceProvider serviceProvider, ILogger<RecipePageController> logger)
        {
            _contentLoader = contentLoader;  
            _commentService = commentService;
            _contentRepository = contentRepository;  //används inte
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(RecipePage currentPage)
        {
            var model = new RecipePageViewModel(currentPage);

            var comments = _commentService.GetCommentsByPage(currentPage.Id);
            if (comments != null)
            {
                model.Comments = comments;
            }

            //try
            //{
            //    var comments = _commentService.GetCommentsByPage(currentPage.Id);
            //    model.Comments = comments;
            //}
            //catch (Exception ex) { _logger.LogError(ex.Message); }
            ViewData["UserComment"] = model.Comments;
            return View(model);
        }




        [HttpPost]
        public IActionResult PostComment(string commentText, int pageId)
        {            
            var newComment = new Comment
            {
                PageId = pageId,
                Text = commentText 
            };

            _commentService.Save(newComment);

            //try
            //{
            //    _commentService.Save(newComment);
            //}
            //catch (Exception ex) { _logger.LogError(ex.Message); }


            var parent = GetParent();
            var c = _contentLoader.GetChildren<RecipePage>(parent).Where(x => x.Id == pageId).FirstOrDefault();

            var urlHelper = _serviceProvider.GetInstance<UrlResolver>();
            var friendlyUrl = urlHelper.GetUrl(c.ContentLink);
            
            return Redirect(friendlyUrl);

        }

        public ContentReference GetParent()
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var settingsPages = new List<SettingsPage>();
            startPage.GetDescendantsOfType(settingsPages);
            var settingsPage = settingsPages.FirstOrDefault();

            if (settingsPage != null)
            {
                var parent = settingsPage.RecipesContainer;

                if (parent != null)
                {
                    return parent;
                }
            }

            return null;
        }
    }
}
