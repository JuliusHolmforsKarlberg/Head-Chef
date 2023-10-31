using EPiServer.Web;
using Head_Chef.Business.Extensions;
using Head_Chef.Models.Pages;
using Head_Chef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Head_Chef.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentRepository _contentRepository;

        private readonly string apiKey = "03ee5cb13a274be5a31d9594f779bfb9";

        public SearchPageController(IContentLoader contentLoader, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;
            _contentRepository = contentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(SearchPage currentPage, string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&query={query}");
            var response = await client.SendAsync(request);
            var status = response.EnsureSuccessStatusCode();
            var model = new SearchPageViewModel(currentPage);

            if (status.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                var recipes = JsonConvert.DeserializeObject<RecipeCardsViewModel.Root>(result.Result); // MoviesViewModel är den kortare

                if (recipes != null)
                {
                    //var parent = GetParent();

                    //if (parent != null) // Här ligger felet - parent == null dvs RecipesContainer är tom i SettingsPage
                    //{
                    //    var filteredRecipes = new List<RecipeCardsViewModel.Result>();

                    //    foreach (var item in recipes.Results.ToList())
                    //    {
                    //        //if (!MovieExists(parent, item.ImdbID))
                    //        //{
                    //        //    filteredMovies.Add(item);
                    //        //}
                    //        filteredRecipes.Add(item);
                    //    }

                    //    //model.Movies = filteredMovies;
                    //    model.Recipes = filteredRecipes;
                    //}

                    model.Recipes = recipes.Results;
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync(SearchPage currentPage, string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/complexSearch{id}");
            var response = await client.SendAsync(request);
            var status = response.EnsureSuccessStatusCode();
            var model = new SearchPageViewModel(currentPage);

            if (status.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                var movie = JsonConvert.DeserializeObject<MovieViewModel.Root>(result.Result);

                if (movie != null)
                {
                    var parent = GetParent();

                    if (parent != null)
                    {
                        var page = _contentRepository.GetDefault<MoviePage>(parent);

                        page.Name = movie.Title;
                        page.Title = movie.Title;
                        page.Poster = movie.Poster != null ? movie.Poster : "~/static/img/default-poster.jpg";
                        page.Year = movie.Year;
                        page.ImdbRating = movie.ImdbRating;
                        page.ImdbID = movie.ImdbID;
                        page.Genre = movie.Genre;
                        page.Plot = movie.Plot;

                        _contentRepository.Save(page, EPiServer.DataAccess.SaveAction.Publish);
                    }
                }
            }

            return LocalRedirect("/");
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
                //var parent = settingsPage.MoviesContainer; //här
                var parent = settingsPage.RecipesContainer;

                if (parent != null)
                {
                    return parent;
                }
            }

            return null;
        }


        private bool MovieExists(ContentReference parent, string imdbID)
        {
            var child = _contentLoader.GetChildren<MoviePage>(parent).Where(x => x.ImdbID == imdbID).FirstOrDefault();

            if (child == null)
            {
                return false;
            }

            return true;
        }
    }
}
