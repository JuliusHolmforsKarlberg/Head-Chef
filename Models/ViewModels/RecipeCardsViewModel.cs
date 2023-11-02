using Newtonsoft.Json;

namespace Head_Chef.Models.ViewModels
{
    public class RecipeCardsViewModel
    {
        public class Root
        {

            [JsonProperty("results")]
            public List<Result> Results { get; set; }

            [JsonProperty("totalResults")]
            public int TotalResults { get; set; }

        }
        public class Result
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }

            [JsonProperty("imageType")]
            public string ImageType { get; set; }

        }

    }
}
