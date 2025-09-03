using System.Text.Json;
using System.Text;

namespace DemoDayCQRSProject.Services
{
    public class RapidAiService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _host;
        private readonly string _endpoint;

        public RapidAiService(HttpClient http, string apiKey, string host, string endpoint)
        {
            _http = http;
            _apiKey = apiKey;
            _host = host;
            _endpoint = endpoint;
        }
        public async Task<string> GenerateReplyAsync(string userMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
            request.Headers.Add("x-rapidapi-key", _apiKey);
            request.Headers.Add("x-rapidapi-host", _host);

            var payload = new { text = userMessage };
            request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // Beklenen format: { "result": "AI cevabı burada" }
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("result", out var r))
                return r.GetString() ?? "Yanıt alınamadı.";

            return "Yanıt alınamadı.";
        }






    }
}
