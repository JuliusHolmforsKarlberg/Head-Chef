using Newtonsoft.Json;

namespace Head_Chef.Models.ViewModels
{
    public class RecipeCardsViewModel
    {
        public class Root
        {


            [JsonProperty("results")]
            public List<Result> Results { get; set; }

            //[JsonProperty("totalResults")]
            //public int TotalResults { get; set; }


        }
        public class Result
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }

            //[JsonProperty("imageType")]
            //public string ImageType { get; set; }



            //[JsonProperty("vegetarian")]
            //public bool Vegetarian { get; set; }

            //[JsonProperty("vegan")]
            //public bool Vegan { get; set; }

            //[JsonProperty("glutenFree")]
            //public bool GlutenFree { get; set; }

            //[JsonProperty("dairyFree")]
            //public bool DairyFree { get; set; }

            //[JsonProperty("veryHealthy")]
            //public bool VeryHealthy { get; set; }

            //[JsonProperty("cheap")]
            //public bool Cheap { get; set; }

            //[JsonProperty("veryPopular")]
            //public bool VeryPopular { get; set; }

            //[JsonProperty("sustainable")]
            //public bool Sustainable { get; set; }

            //[JsonProperty("lowFodmap")]
            //public bool LowFodmap { get; set; }

            //[JsonProperty("weightWatcherSmartPoints")]
            //public int WeightWatcherSmartPoints { get; set; }



            //    [JsonProperty("preparationMinutes")]
            //    public int PreparationMinutes { get; set; }

            //    [JsonProperty("cookingMinutes")]
            //    public int CookingMinutes { get; set; }

            //    [JsonProperty("aggregateLikes")]
            //    public int AggregateLikes { get; set; }

            //    [JsonProperty("healthScore")]
            //    public int HealthScore { get; set; }

            //    [JsonProperty("sourceName")]
            //    public string SourceName { get; set; }

            //    [JsonProperty("pricePerServing")]
            //    public double PricePerServing { get; set; }

            //    [JsonProperty("id")]
            //    public int Id { get; set; }

            //    [JsonProperty("title")]
            //    public string Title { get; set; }

            //    [JsonProperty("readyInMinutes")]
            //    public int ReadyInMinutes { get; set; }

            //    [JsonProperty("servings")]
            //    public int Servings { get; set; }

            //    [JsonProperty("image")]
            //    public string Image { get; set; }

            //    [JsonProperty("imageType")]
            //    public string ImageType { get; set; }

            //    [JsonProperty("summary")]
            //    public string Summary { get; set; }

            //    [JsonProperty("cuisines")]
            //    public List<string> Cuisines { get; set; }

            //    [JsonProperty("dishTypes")]
            //    public List<string> DishTypes { get; set; }

            //    [JsonProperty("diets")]
            //    public List<string> Diets { get; set; }

            //    [JsonProperty("occasions")]
            //    public List<string> Occasions { get; set; }

            //    [JsonProperty("spoonacularSourceUrl")]
            //    public string SpoonacularSourceUrl { get; set; }
        }

    }
}
