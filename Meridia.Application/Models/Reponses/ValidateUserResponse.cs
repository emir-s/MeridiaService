using System;
namespace Meridia.Application.Models.Reponses
{
	public class ValidateUserResponse
	{
		public Guid UserID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
	}
}

