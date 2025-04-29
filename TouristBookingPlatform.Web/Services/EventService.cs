using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using TouristBookingPlatform.Web.Models;

namespace TouristBookingPlatform.Web.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Event>>("https://localhost:5001/api/events");
            return response ?? new List<Event>();
        }
        public async Task CreateEventAsync(Event ev)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:5001/api/events", ev);
        }

    }


}
