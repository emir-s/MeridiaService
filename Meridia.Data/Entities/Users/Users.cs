using System;
using System.ComponentModel.DataAnnotations;
using Meridia.Domain.Entities.Common;

namespace Meridia.Domain.Entities.Users
{
    public class Users : BaseEntity
    {
        [Key]
        public Guid UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IdentityNo { get; set; }
        public ICollection<UserLocations> UserLocations { get; set; }
    }
}


