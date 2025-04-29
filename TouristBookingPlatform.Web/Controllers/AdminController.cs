using Microsoft.AspNetCore.Mvc;
using TouristBookingPlatform.Web.Services;
using TouristBookingPlatform.Web.Models;
using Microsoft.AspNetCore.Authorization;


namespace TouristBookingPlatform.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly EventService _eventService;

        public AdminController(EventService eventService)
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

        public async Task<IActionResult> Edit(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null)
                return NotFound();

            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event ev)
        {
            if (id != ev.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(ev);

            await _eventService.UpdateEventAsync(ev);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null)
                return NotFound();

            return View(ev);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
