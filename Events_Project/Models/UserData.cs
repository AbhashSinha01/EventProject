using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_Project.Models
{
    [NotMapped]
    public class UserData
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
    [NotMapped]
    public class Address
    {
        [Key]
        public int AddressId{ get; set; }
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? zipcode { get; set; }
        [ForeignKey("Geo")]
        public int GeoId { get; set; }
        public Geo? Geo { get; set; }
    }
    [NotMapped]
    public class Geo
    {
        [Key]
        public int GeoId { get; set; }
        public string? Lat { get; set; }
        public string? Lng { get; set; }
    }
    [NotMapped]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string? name { get; set; }
        public string? catchPhrase { get; set; }
        public string? bs { get; set; }
    }
}
