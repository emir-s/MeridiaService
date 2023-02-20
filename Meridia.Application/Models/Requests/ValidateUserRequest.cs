using System;
namespace Meridia.Application.Models.Requests
{
	public class ValidateUserRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

