using System.ComponentModel.DataAnnotations;

namespace Meridia.Domain.Entities.Locations;

public class City
{
    [Key]
    public Guid CityID { get; set; }
    public string CityName { get; set; }
    public string CityCode { get; set; }
    public ICollection<District> Districts { get; set; }
}