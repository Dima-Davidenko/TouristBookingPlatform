using System.Net.Http;
using System.Net.Http.Json;
using TouristBookingPlatform.Web.Models;
using Microsoft.Extensions.Configuration;

namespace TouristBookingPlatform.Web.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EventService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiBaseUrl = config["ApiBaseUrl"];
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            const int maxRetries = 3;
            const int delayMilliseconds = 1000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/events");

                    if (response.IsSuccessStatusCode)
                    {
                        var events = await response.Content.ReadFromJsonAsync<IEnumerable<Event>>();
                        return events ?? new List<Event>();
                    }

                    // Only retry on 500-level errors
                    if ((int)response.StatusCode >= 500 && (int)response.StatusCode < 600)
                    {
                        if (attempt < maxRetries)
                            await Task.Delay(delayMilliseconds);
                    }
                    else
                    {
                        // For non-500 errors, break and throw immediately
                        response.EnsureSuccessStatusCode();
                    }
                }
                catch (HttpRequestException ex) when (attempt < maxRetries)
                {
                    // Optionally log the error here
                    await Task.Delay(delayMilliseconds);
                }
            }

            throw new Exception("Failed to retrieve events after multiple attempts.");
        }

        public async Task CreateEventAsync(Event ev)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/events", ev);
            response.EnsureSuccessStatusCode(); // optional: add retry here too if needed
        }
    }
}
