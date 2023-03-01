using System;
using Meridia.Domain.Entities.Users;

namespace Meridia.Application.Models.DTOs
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? IdentityNo { get; set; }

        public UserDTO(Users users)
        {
            UserID = users.UserID;
            Name = users.Name;
            Surname = users.Surname;
            Email = users.Email;
            IdentityNo = users.IdentityNo;
        }
    }
}