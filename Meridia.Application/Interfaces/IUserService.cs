using System;
using Meridia.Application.Models.Reponses;
using Meridia.Application.Models.Requests;

namespace Meridia.Application.Interfaces
{
	public interface IUserService
	{
        Task<CreateUserResponse> CreateUser(CreateUserRequest req);
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest req);
    }
}

