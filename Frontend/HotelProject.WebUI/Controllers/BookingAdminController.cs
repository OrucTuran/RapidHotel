using HotelProject.WebUI.DTOs.BookingDTO;
using HotelProject.WebUI.DTOs.GuestDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:2424/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/Booking/BookingApproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> CancelReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/Booking/BookingCanceled?id={id}");
            try
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return View();

        }

        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/Booking/BookingWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(ApprovedReservationBookingDTO approvedReservationBookingDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationBookingDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:2424/api/bbb/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDTO updateBookingDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:2424/api/Booking/UpdateBooking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
    }
}
