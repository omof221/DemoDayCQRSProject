namespace DemoDayCQRSProject.Services
{
    public class GooglePlacesService
    { private readonly HttpClient _httpClient;

        public GooglePlacesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "84ced9dd6fmsh71b7ade120a23b5p1f8929jsn53c5cfe7ed7f");
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "google-map-places.p.rapidapi.com");
        }



        public async Task<string> FindPlaceFromTextAsync(string input)
        {
            var url = $"https://google-map-places.p.rapidapi.com/maps/api/place/findplacefromtext/json?input={Uri.EscapeDataString(input)}&inputtype=textquery&fields=formatted_address,name,geometry";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }



    }
}
