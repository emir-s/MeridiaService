using System.ComponentModel.DataAnnotations;

namespace Meridia.Domain.Entities.Locations;

public class City
{
    [Key]
    public Guid CityID { get; set; }
    public string CityName { get; set; }
    public string CityCode { get; set; }
    public Guid CountryID { get; set; }
    public Country Country { get; set; }
    public ICollection<District> Districts { get; set; }
}