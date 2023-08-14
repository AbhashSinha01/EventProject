using Events_Project.Models;
using Events_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Events_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IMemoryCache _cache;
        public EventsController(IUser user,IMemoryCache cache)
        {
            _user = user;
            _cache = cache;
            
            
        }
        [HttpGet]
        [Route("getAllEvents")]
        public async Task<IActionResult> getAllEvents()
        {
            var result=await _user.GetEvents();
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllEventsById")]
        public async Task<IActionResult> getAllEventsById([FromBody] int id)
        {
            var result= await _user.GetEventsById(id);
            return Ok(result);

        }
        [HttpPost]
        [Route("AddEvents")]
        public async Task<IActionResult> AddEvents([FromBody]Event events)
        {
            var result=await _user.CreateUserEvents(events);
            return Ok(result);

        }

        [HttpPut]
        [Route("UpdateEvents")]
        public async Task<IActionResult> UpdateEvents([FromBody] Event events)
        {
            var result=await _user.UpdateUserEvents(events);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteEvents")]
        public async Task<string> DeleteEvents([FromBody] int id)
        {
            await _user.DeleteUserEvents(id);
            return "Events Deleted Sucessfully!!";
        }

        [HttpPost]
        [Route("CheckUserEventsParticpate")]
        public async Task<string> CheckUserEventsParticpate([FromBody] int UserId)
        {
            var data = await _user.CheckUserEvents(UserId);
            return $"{data}";
        }

        [HttpGet]
        [Route("GetAllEventsByCache")]
        public async Task<IActionResult> GetAllEventsByCache()
        {
            if (_cache.TryGetValue("allEvents", out List<Event> cachedEvents))
            {
                // Return cached events
                return Ok(cachedEvents);
            }
            else
            {
                var result = await _user.GetEvents();
                _cache.Set("allEvents", result, TimeSpan.FromMinutes(10)); 
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("GetAllEventsByIdCache")]
        public async Task<IActionResult> GetAllEventsByIdCache([FromBody] int id)
        {
            var cacheKey = $"event:{id}";

            if (_cache.TryGetValue(cacheKey, out Event cachedEvent))
            {
                // Return cached event by ID
                return Ok(cachedEvent);
            }
            else
            {
                var result = await _user.GetEventsById(id);
                if (result != null)
                {
                    _cache.Set(cacheKey, result, TimeSpan.FromMinutes(10)); // Cache event for 10 minutes
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [Route("AddEventsByCache")]
        public async Task<IActionResult> AddEventsByCache([FromBody] Event events)
        {
            var result = await _user.CreateUserEvents(events);
            _cache.Remove("allEvents"); 
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateEventsByCache")]
        public async Task<IActionResult> UpdateEventsByCache([FromBody] Event events)
        {
            var result = await _user.UpdateUserEvents(events);
            _cache.Remove($"event:{events.EventId}"); 
            _cache.Remove("allEvents"); 
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEventsByCache")]
        public async Task<string> DeleteEventsByCache([FromBody] int id)
        {
            await _user.DeleteUserEvents(id);
            _cache.Remove($"event:{id}"); 
            _cache.Remove("allEvents"); 
            return "Event Deleted Successfully!!";
        }

        [HttpPost]
        [Route("InvitedUsers")]
        public async Task<string> InvitedUsers([FromBody] Event UserId)
        {
            var result = await _user.CreateUserEvents(UserId);
            return $"Invited User  Successfully To the Events!!";

        }
        [HttpPost]
        [Route("Add Users")]
        public async Task<string> InvitedUsersgeo([FromBody] Event UserId)
        {
            var result = await _user.CreateUserEvents(UserId);
            return $"Invited User  Successfully To the Events!!";
        }
    }
}
