using System.ComponentModel.DataAnnotations;
using Meridia.Domain.Entities.Common;

namespace Meridia.Domain.Entities.Locations;

public class Address : BaseEntity
{
    [Key]
    public Guid AddressID { get; set; }
    public string AddressName { get; set; }
    public string Description { get; set; }
    public Guid DistrictID { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public District District { get; set; }
}