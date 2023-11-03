using Head_Chef.Models.Pages;
using Newtonsoft.Json;
using static Head_Chef.Models.ViewModels.RecipeViewModel;

namespace Head_Chef.Models.ViewModels
{
    public class RecipePageViewModel : PageViewModel<RecipePage>
    {
        public RecipePageViewModel(RecipePage currentPage) : base(currentPage)
        {
        }
        [JsonProperty("vegetarian")]
        public bool Vegetarian { get; set; }

        [JsonProperty("vegan")]
        public bool Vegan { get; set; }

        [JsonProperty("glutenFree")]
        public bool GlutenFree { get; set; }

        [JsonProperty("dairyFree")]
        public bool DairyFree { get; set; }

        [JsonProperty("veryHealthy")]
        public bool VeryHealthy { get; set; }

        [JsonProperty("cheap")]
        public bool Cheap { get; set; }

        [JsonProperty("veryPopular")]
        public bool VeryPopular { get; set; }

        [JsonProperty("sustainable")]
        public bool Sustainable { get; set; }

        [JsonProperty("lowFodmap")]
        public bool LowFodmap { get; set; }

        [JsonProperty("weightWatcherSmartPoints")]
        public int WeightWatcherSmartPoints { get; set; }

        [JsonProperty("preparationMinutes")]
        public int PreparationMinutes { get; set; }

        [JsonProperty("cookingMinutes")]
        public int CookingMinutes { get; set; }

        [JsonProperty("aggregateLikes")]
        public int AggregateLikes { get; set; }

        [JsonProperty("healthScore")]
        public int HealthScore { get; set; }

        [JsonProperty("pricePerServing")]
        public double PricePerServing { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; } // //

        [JsonProperty("title")]
        public string Title { get; set; } // //

        [JsonProperty("readyInMinutes")]
        public int ReadyInMinutes { get; set; } // //

        [JsonProperty("servings")]
        public int Servings { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; } // //

        [JsonProperty("summary")]
        public string Summary { get; set; } // //        

        [JsonProperty("instructions")]
        public string Instructions { get; set; } // //

        [JsonProperty("spoonacularSourceUrl")]
        public string SpoonacularSourceUrl { get; set; }  // //

        /////////////


        [JsonProperty("extendedIngredients")]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }
    }

    public class ExtendedIngredient
    {
        [JsonProperty("id")]
        public int Id { get; set; }        

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameClean")]
        public string NameClean { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("meta")]
        public List<string> Meta { get; set; }

        [JsonProperty("measures")]
        public Measures Measures { get; set; }
    }
}
