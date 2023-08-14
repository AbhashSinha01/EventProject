using Events_Project.Models;

namespace Events_Project.Repository
{
    public interface IUser
    {
        Task<List<Event>> GetEvents();
        Task<Event> GetEventsById(int id);
        Task<string> CreateUserEvents(Event events);
        Task<string> UpdateUserEvents(Event events);
        Task<string> DeleteUserEvents(int eventId);
        Task<string> CheckUserEvents(int UserId); 
    }
}
