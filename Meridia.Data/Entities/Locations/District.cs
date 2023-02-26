using System.ComponentModel.DataAnnotations;

namespace Meridia.Domain.Entities.Locations;

public class District
{
    [Key]
    public Guid DistrictID { get; set; }
    public string DistrictName { get; set; }
    public string DistrictCode { get; set; }
    public Guid CityID { get; set; }
    public City City { get; set; }
    public ICollection<Address> Addresses { get; set; }
}