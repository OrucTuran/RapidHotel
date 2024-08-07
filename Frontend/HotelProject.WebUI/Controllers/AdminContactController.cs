using HotelProject.WebUI.DTOs.ContactDTO;
using HotelProject.WebUI.DTOs.SendMessageDTO;
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
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            // Gelen Kutusu İsteği
            var inboxResponse = await GetApiResponseAsync("http://localhost:2424/api/Contact");
            if (inboxResponse != null)
            {
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(inboxResponse);
                ViewBag.contactCount = values.Count;

                // Giden Kutusu Sayısı İsteği
                var sendboxCountResponse = await GetApiResponseAsync("http://localhost:2424/api/SendMessage/GetSendMessageCount");
                ViewBag.sendMessageCount = sendboxCountResponse ?? "0"; // Hata durumunda default değer

                return View(values);
            }
            return BadRequest();
        }



        public async Task<IActionResult> Sendbox()
        {
            // Giden Kutusu İsteği
            var sendboxResponse = await GetApiResponseAsync("http://localhost:2424/api/SendMessage");
            if (sendboxResponse != null)
            {
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDTO>>(sendboxResponse);
                ViewBag.sendMessageCount = values.Count;

                // Gelen Kutusu Sayısı İsteği
                var inboxCountResponse = await GetApiResponseAsync("http://localhost:2424/api/Contact/GetContactCount");
                ViewBag.contactCount = inboxCountResponse ?? "0"; // Hata durumunda default değer

                return View(values);
            }
            return BadRequest();
        }


        private async Task<string> GetApiResponseAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }


        public async Task<IActionResult> AddSendMessage()
        {
            // Gelen Kutusu Sayısı İsteği
            var inboxCountResponse = await GetApiResponseAsync("http://localhost:2424/api/Contact/GetContactCount");
            ViewBag.contactCount = inboxCountResponse ?? "0"; // Hata durumunda default değer

            // Giden Kutusu Sayısı İsteği
            var sendboxCountResponse = await GetApiResponseAsync("http://localhost:2424/api/SendMessage/GetSendMessageCount");
            ViewBag.sendMessageCount = sendboxCountResponse ?? "0"; // Hata durumunda default değer

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDTO createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "Admin";
            createSendMessage.Date = DateTime.Today;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:2424/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:2424/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:2424/api/Contact/GetContactCount");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}
    }
}
