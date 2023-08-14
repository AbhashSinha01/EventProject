using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_Project.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string? EventDescription { get; set; }
        [ForeignKey("timeZoneData")]
        public int TimeZoneId { get; set; }
        public TimeZoneData? timeZoneData { get; set; }
        [ForeignKey("userData")]
        public int UserId { get; set; }
        public UserData? userData { get; set; }
    }

    public class TimeZoneData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? TimeZoneName { get; set; }
    }
}
