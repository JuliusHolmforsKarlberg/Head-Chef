﻿using Newtonsoft.Json;

namespace Head_Chef.Models.ViewModels
{
    public class MoviesViewModel
    {
        public class Root
        {
            [JsonProperty("Search")]
            public List<Search> Search { get; set; }

            [JsonProperty("totalResults")]
            public string TotalResults { get; set; }

            [JsonProperty("Response")]
            public string Response { get; set; }
        }

        public class Search
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Year")]
            public string Year { get; set; }

            [JsonProperty("imdbID")]
            public string ImdbID { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("Poster")]
            public string Poster { get; set; }
        }
    }
}