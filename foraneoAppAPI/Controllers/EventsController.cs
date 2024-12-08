using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using foraneoApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace foraneoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsApiController : ControllerBase
    {
        private readonly IWorkContainer _workContainer;

        public EventsApiController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }

        // GET: api/events
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _workContainer.Event.GetAll(includeProperties: "category")
                .Select(e => new
                {
                    e.eventId,
                    e.title,
                    e.description,
                    e.location,
                    e.startDate,
                    e.creationDate,
                    categoryName = e.category.categoryName
                });

            return Ok(new { data = events });
        }

        // GET: api/events/{id}
        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var eventObj = _workContainer.Event.Get(id, includeProperties: "category");
            if (eventObj == null)
            {
                return NotFound(new { message = "Event not found" });
            }

            var eventResult = new
            {
                eventObj.eventId,
                eventObj.title,
                eventObj.description,
                eventObj.location,
                eventObj.startDate,
                eventObj.creationDate,
                categoryName = eventObj.category.categoryName
            };

            return Ok(new { data = eventResult });
        }

        // POST: api/events
        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event eventModel)
        {
            if (eventModel == null)
            {
                return BadRequest(new { message = "Invalid event data" });
            }

            _workContainer.Event.Add(eventModel);
            _workContainer.Save();

            return CreatedAtAction(nameof(GetEvent), new { id = eventModel.eventId }, eventModel);
        }

        // PUT: api/events/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] Event eventModel)
        {
            if (eventModel == null || eventModel.eventId != id)
            {
                return BadRequest(new { message = "Event data is invalid" });
            }

            var existingEvent = _workContainer.Event.Get(id);
            if (existingEvent == null)
            {
                return NotFound(new { message = "Event not found" });
            }

            _workContainer.Event.Update(eventModel);
            _workContainer.Save();

            return Ok(new { message = "Event updated successfully" });
        }

        // DELETE: api/events/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var eventObj = _workContainer.Event.Get(id);
            if (eventObj == null)
            {
                return NotFound(new { message = "Event not found" });
            }

            _workContainer.Event.Remove(eventObj);
            _workContainer.Save();

            return Ok(new { message = "Event deleted successfully" });
        }
    }
}
