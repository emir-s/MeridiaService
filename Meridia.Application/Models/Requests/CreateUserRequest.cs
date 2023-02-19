using System;
using System.ComponentModel.DataAnnotations;

namespace Meridia.Application.Models.Requests
{
	public class CreateUserRequest
	{
       
            [Required]
            [MaxLength(50)]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(50)]
            public string LastName { get; set; }

            [Required]
            [MaxLength(50)]
            public string Email { get; set; }

            [Required]
            [MaxLength(11)]
            public string IdentityNo { get; set; }

            [Required]
            [MaxLength(50)]
            public string Password { get; set; }


    }
}

