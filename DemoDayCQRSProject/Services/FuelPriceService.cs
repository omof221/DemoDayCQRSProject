using Newtonsoft.Json.Linq;

namespace DemoDayCQRSProject.Services
{
    public class FuelPriceService
    {
        private readonly HttpClient _httpClient;

        public FuelPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<JObject> GetFuelPricesAsync(string city)
        {
            string url = $"http://hasanadiguzel.com.tr/api/akaryakit/sehir={city}";
            var response = await _httpClient.GetStringAsync(url);
            //Console.WriteLine(response);

            return JObject.Parse(response);
        }





    }
}
