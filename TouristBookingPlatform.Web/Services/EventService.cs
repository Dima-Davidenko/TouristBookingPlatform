using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using TouristBookingPlatform.Web.Models;

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
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Event>>($"{_apiBaseUrl}/api/events");
            return response ?? new List<Event>();
        }

        public async Task CreateEventAsync(Event ev)
        {
            await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/events", ev);
        }
    }
}
