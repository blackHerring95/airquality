using AirQualityWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AirQualityWebApp.Pages
{
    public class CityAirQualityModel : PageModel
    {
        public CityAirQuality CityAirQuality { get; set; }

        private readonly string APIKEY = "19403d82ea6df00fc8d9bcb168ddb61163647451";
        public async Task OnGet(string cityName)
        {
            try
            {
                var httpClient = new HttpClient();

                var apiUrl = $"https://api.waqi.info/feed/{cityName}/?token={APIKEY}";

                if (cityName == null)
                {
                    apiUrl = $"https://api.waqi.info/feed/here?token={APIKEY}";
                }

                var result = await httpClient.GetAsync(new Uri(apiUrl));

                if (!result.IsSuccessStatusCode)
                {
                    Page();
                }

                var modelStr = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(modelStr))
                {
                    RedirectToPage("Error");
                }

                var model = JsonConvert.DeserializeObject<CityAirQuality>(modelStr)!;
                if(model == null) 
                {
                    CityAirQuality = new CityAirQuality();
                }
                else
                {
                    CityAirQuality = model;
                }
                
            }
            catch (Exception ex)
            {
                CityAirQuality = new CityAirQuality();
                RedirectToPage("AirQuality");
            }
        }
    }
}
