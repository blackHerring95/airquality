using AirQualityWebApp.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AirQualityWebApp.Pages
{
    public class AirQualityModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public AirQualityQuery? Query { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Query != null) return RedirectToPage("CityAirQuality", new {CityName = Query.CityName});

                return RedirectToPage("CityAirQuality", new { CityName = "" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
