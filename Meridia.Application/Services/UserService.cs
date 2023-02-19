using System;
using Meridia.Application.Core.Repositories;
using Meridia.Application.Core.Services;
using Meridia.Application.Interfaces;
using Meridia.Application.Models.DTOs;
using Meridia.Application.Models.Reponses;
using Meridia.Application.Models.Requests;
using Meridia.Domain.Entities.Users;

namespace Meridia.Application.Services
{
	public class UserService : IUserService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest req)
        {
            var user = await _unitOfWork.Repository<Users>().AddAsync(new Users
            {
                Name = req.FirstName,
                Surname = req.LastName,
                Email = req.Email,
                Password = req.Password,
                IdentityNo = req.IdentityNo
            });
            await _unitOfWork.SaveChangesAsync();
            return new CreateUserResponse() { Data = new UserDTO(user) };
        }
    }
}

