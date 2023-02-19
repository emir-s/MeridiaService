using System;
using Meridia.Domain.Entities.Users;

namespace Meridia.Application.Models.DTOs
{
	public class UserDTO
	{
		public Guid UserID { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? IdentityNo { get; set; }
        public UserDTO(Users users)
		{
			UserID = users.UserID;
			NameSurname = users.Name + " " + users.Surname;
			Email = users.Email;
			IdentityNo = users.IdentityNo;
		}
	}
}

