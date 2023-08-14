using Events_Project.Models;
using Events_Project.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Events_Project.Services
{
    public class EventsServices : IUser
    {
        private readonly ApplicationDbContext _context;
        public EventsServices(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<List<Event>> GetEvents()
        {
            var eventsTimeZone=await _context.Events.Include(e=>e.timeZoneData).ToListAsync();
            var eventsList=new List<Event>();
            foreach (var e in eventsTimeZone)
            {
                eventsList.Add(new Event
                {
                    EventId = e.EventId,
                    EventTitle = e.EventTitle,
                    EventDescription = e.EventDescription,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    TimeZoneId = e.TimeZoneId,
                    timeZoneData = e.timeZoneData,
                    UserId = e.UserId,
                    userData = e.userData,

                });
            }
      
            return eventsList;
        }
        public async Task<Event> GetEventsById([FromBody] int id)
        {
            return await _context.Events.FindAsync(id);
        }
        public async Task<string> CreateUserEvents([FromBody]Event events)
        {
            var currentUtc=DateTime.UtcNow;
            new TimeZoneData
            {
                TimeZoneName = events.timeZoneData.TimeZoneName

            };
          
            await _context.Events.AddAsync(events);
            var data=await _context.SaveChangesAsync();
            return $"{data} events Created Sucessfully";
        }
        public async Task<string> UpdateUserEvents([FromBody] Event updatedEvent)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(x=>x.EventId== updatedEvent.EventId);
            var timeZoneValue = updatedEvent.timeZoneData.TimeZoneName;
            if (existingEvent!=null)
            {
                _context.Events.Entry(existingEvent).State = EntityState.Detached;
                _context.Entry(updatedEvent).State = EntityState.Modified;
                var result=await _context.SaveChangesAsync();
                return $"{result} Events Updated Succesffuly";
            }
            else
            {
                return $"Events Not Updated!!";
            }
        }

        public async Task<string> DeleteUserEvents([FromBody] int eventId)
        {
            var eventToDelete=await _context.Events.FindAsync(eventId);
            if(eventToDelete!=null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return $"Events Deleted Sucessfully!!";
            }
            else
            {
                return $"Events Not Deleted";
            }
        }

        public async Task<string> CheckUserEvents([FromBody] int UserId)
        {
            var obj=await _context.Events.FirstOrDefaultAsync();
            if (UserId == obj.UserId)
            {
                return $"Users Already Particapted in Events";

            }
            else
            {
                return $"Please Registered In Events";
            }
        }
    }
}
