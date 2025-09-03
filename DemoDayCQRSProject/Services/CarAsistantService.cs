using System.Text;
using System.Text.Json;

namespace DemoDayCQRSProject.Services
{
    public class CarAsistantService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://chatgpt-vision1.p.rapidapi.com/matagvision2";
        public CarAsistantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "84ced9dd6fmsh71b7ade120a23b5p1f8929jsn53c5cfe7ed7f");
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "chatgpt-vision1.p.rapidapi.com");
        }
        public async Task<string> GetCarSuggestionAsync(string userInput)
        {
            var payload = new
            {
                messages = new[]
                {
            new {
                role = "user",
                content = new[]
                {
                    new { type = "text", text = $"Sen bir araç kiralama uzmanısın. Kullanıcı şunu soruyor: {userInput} bunlardan en iyi 3 seçeniği detaylı olarak açıkla ve bu araçların km ye göre yaktıkları yakıt miktarlarnı da ekle " }
                }
            }
        }
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return $"API Hatası: {response.StatusCode} - {error}";
            }

            var result = await response.Content.ReadAsStringAsync();

            // ✅ Sadece "result" alanını çek
            using var doc = JsonDocument.Parse(result);
            if (doc.RootElement.TryGetProperty("result", out var text))
            {
                return text.GetString();
            }

            return result;
        }
    }
}
