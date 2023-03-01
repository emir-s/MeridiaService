using System.ComponentModel.DataAnnotations;
using Meridia.Domain.Entities.Locations;

namespace Meridia.Domain.Entities.Users;

public class UserLocations
{
    [Key]
    public Guid UserLocationsID { get; set; }
    public Guid UserID { get; set; }
    public Guid AddressID { get; set; }
    public string LocationName { get; set; }
    public int IsActive { get; set; }
    public int IsPrimary { get; set; }
    public Users User { get; set; }
    public Address Address { get; set; }
}