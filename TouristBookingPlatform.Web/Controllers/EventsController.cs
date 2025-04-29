using Microsoft.AspNetCore.Mvc;
using TouristBookingPlatform.Web.Models;
using TouristBookingPlatform.Web.Services;

namespace TouristBookingPlatform.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEventsAsync();
            return View(events);
        }
    }
}
