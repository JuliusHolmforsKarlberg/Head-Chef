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
                var recipes = JsonConvert.DeserializeObject<RecipeCardsViewModel.Root>(result.Result);

                if (recipes != null)
                {
                    var parent = GetParent();

                    if (parent != null) 
                    {
                        var filteredRecipes = new List<RecipeCardsViewModel.Result>();

                        foreach (var item in recipes.Results.ToList())
                        {
                            if (!RecipeExists(parent, item.Id))
                            {
                                filteredRecipes.Add(item);
                            }
                            //filteredRecipes.Add(item);
                        }
                        model.Recipes = filteredRecipes;
                    }
                    model.TotalResults = recipes.TotalResults;
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync(SearchPage currentPage, string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/{id}/information?apiKey={apiKey}");
            var response = await client.SendAsync(request);
            var status = response.EnsureSuccessStatusCode();
            var model = new SearchPageViewModel(currentPage);

            if (status.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                //var recipe = JsonConvert.DeserializeObject<SimplyfiedRecipeViewModel.Root>(result.Result);
                var recipe = JsonConvert.DeserializeObject<RecipePageViewModel>(result.Result);

                if (recipe != null)
                {
                    var parent = GetParent();

                    if(parent != null)
                    {
                        var page = _contentRepository.GetDefault<RecipePage>(parent);

                        page.Name = recipe.Title;
                        page.Title = recipe.Title;
                        page.Image = recipe.Image;
                        page.Summary = recipe.Summary;
                        page.Instructions = recipe.Instructions;
                        page.ReadyInMinutes = recipe.ReadyInMinutes;
                        page.SpoonacularSourceUrl = recipe.SpoonacularSourceUrl;
                        page.Id = recipe.Id;

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
                var parent = settingsPage.RecipesContainer;

                if (parent != null)
                {
                    return parent;
                }
            }

            return null;
        }


        private bool RecipeExists(ContentReference parent, int Id)
        {
            var child = _contentLoader.GetChildren<RecipePage>(parent).Where(x => x.Id == Id).FirstOrDefault();

            if (child == null)
            {
                return false;
            }

            return true;
        }
    }
}
