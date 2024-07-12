using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMoovieModel> apiMoovieModels = new List<ApiMoovieModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "838b5c03bemsh1fdc2f62ee9ba46p10c0b1jsne57421d8c874" },  //istek atacağımız key
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" }, //apiyi sağlayan link
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMoovieModels = JsonConvert.DeserializeObject<List<ApiMoovieModel>>(body);
                return View(apiMoovieModels);
               
            }
           
        }
    }
}
