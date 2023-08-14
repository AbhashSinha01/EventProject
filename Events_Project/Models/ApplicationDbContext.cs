using Microsoft.EntityFrameworkCore;

namespace Events_Project.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<TimeZoneData> TimeZoneDatas { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
    
}
