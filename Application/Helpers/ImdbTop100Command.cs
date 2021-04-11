using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using WebMVC.Models;

namespace Application.Helpers
{
    public class ImdbTop100Command
    {
        private readonly string _clientUrl = "https://imdb-api.com/en/API/MostPopularMovies";
        private readonly string _requestUrl = "/k_fweq5i39";

        public IRestResponse<ImdbTop100Response> GetTop100()
        {
            var client = new RestClient(_clientUrl);

            var request = new RestRequest(_requestUrl, Method.GET);
            var response = client.Execute<ImdbTop100Response>(request);

            return response;
        }
    }
}
