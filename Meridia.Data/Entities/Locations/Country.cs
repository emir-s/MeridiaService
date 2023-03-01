using System.ComponentModel.DataAnnotations;

namespace Meridia.Domain.Entities.Locations;

public class Country
{
    [Key]
    public Guid CountryID { get; set; }
    public string CountryName { get; set; }
    public string CountryCode { get; set; }
    public ICollection<City> Cities { get; set; }
}