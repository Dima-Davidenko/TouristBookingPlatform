using Microsoft.AspNetCore.Mvc;
using TouristBookingPlatform.Web.Services;
using TouristBookingPlatform.Web.Models;


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

        // Display Create Event Form
        public IActionResult Create()
        {
            return View();
        }

        // Handle Form POST Submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event ev)
        {
            if (!ModelState.IsValid)
                return View(ev);

            await _eventService.CreateEventAsync(ev);
            return RedirectToAction(nameof(Index));
        }

    }
}
