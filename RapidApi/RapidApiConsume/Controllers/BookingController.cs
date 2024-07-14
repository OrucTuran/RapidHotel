using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using RapidApiConsume.Models;

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
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=EUR&checkin_date=2024-09-14&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id=-1746443&adults_number=2&checkout_date=2024-09-27&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "cbf22fb3e3mshe8d554d6e847613p13e296jsn0442d6d65485" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.results.ToList());
            }

        }
    }
}
