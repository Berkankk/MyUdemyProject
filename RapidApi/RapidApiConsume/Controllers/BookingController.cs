﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=AED&checkin_date=2024-09-14&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id=-1446263&adults_number=2&checkout_date=2024-09-15&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "838b5c03bemsh1fdc2f62ee9ba46p10c0b1jsne57421d8c874" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(value.results.ToList());
            }
          
        }
    }
}
