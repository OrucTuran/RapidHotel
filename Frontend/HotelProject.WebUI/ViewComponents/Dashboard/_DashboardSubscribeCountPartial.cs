using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using HotelProject.WebUI.DTOs.FollowersDTO;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DashboardSubscribeCountPartial()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SocialMediaFollowersDTO();

            try
            {
                // Instagram API çağrısı
                var instagramResponse = await GetApiResponse<ResultInstagramFollowersDTO>(
                    "https://instagram-profile1.p.rapidapi.com/getprofile/didemgeziyor",
                    "instagram-profile1.p.rapidapi.com"
                );

                if (instagramResponse != null)
                {
                    model.InstagramFollowers = instagramResponse.followers;
                    model.InstagramFollowing = instagramResponse.following;
                }

                // Twitter API çağrısı
                var twitterResponse = await GetApiResponse<ResultTwitterFollowersDTO>(
                    "https://twitter32.p.rapidapi.com/getProfile?username=MurattYucedag",
                    "twitter32.p.rapidapi.com"
                );

                if (twitterResponse?.data?.user_info != null)
                {
                    model.TwitterFollowers = twitterResponse.data.user_info.followers_count;
                    model.TwitterFollowing = twitterResponse.data.user_info.friends_count;
                }

                // Linkedin API çağrısı
                var linkedinResponse = await GetApiResponse<ResultLinkedinFollowersDTO>(
                    "https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile-by-salesnavurl?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmuratyucedag%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false",
                    "fresh-linkedin-profile-data.p.rapidapi.com"
                );
                if (linkedinResponse != null)
                {
                    model.LinkedinFollowers = linkedinResponse.data.follower_count;
                    model.LinkedinConnections = linkedinResponse.data.connection_count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Hatası: {ex.Message}");
            }

            return View(model);
        }

        private async Task<T?> GetApiResponse<T>(string url, string host) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "cbf22fb3e3mshe8d554d6e847613p13e296jsn0442d6d65485" },
                    { "x-rapidapi-host", host }
                }
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Yanıtı ({host}): {body}"); // Hata ayıklamak için

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API Hatası: {response.StatusCode}");
                    return null;
                }

                return JsonConvert.DeserializeObject<T>(body);
            }
        }
    }
}
