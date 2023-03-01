using System;
using Meridia.Application.Interfaces.Repositories;
using Meridia.Application.Interfaces;
using Meridia.Application.Interfaces.Services;
using Meridia.Application.Models.DTOs;
using Meridia.Application.Models.Reponses;
using Meridia.Application.Models.Requests;
using Meridia.Domain.Entities.Users;
using Meridia.Domain.Exceptions;
using Meridia.Domain.Specifications;

namespace Meridia.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        private readonly ICryptService _cryptService;

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService, ICryptService cryptService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _cryptService = cryptService;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest req)
        {
            var user = await _unitOfWork.Repository<Users>().AddAsync(new Users
            {
                Name = req.FirstName,
                Surname = req.LastName,
                Email = req.Email,
                Password = _cryptService.EncryptPassword(req.Password),
                IdentityNo = req.IdentityNo
            });
            await _unitOfWork.SaveChangesAsync();
            return new CreateUserResponse() { Data = new UserDTO(user) };
        }

        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest req)
        {
            var spec = UserSpecification.GetUserByEmail(req.Email);
            var user = await _unitOfWork.Repository<Users>().FirstOrDefaultAsync(spec);
            if (user is null)
                throw new UserNotFoundException();

            if (!_cryptService.DecryptPassword(req.Password,user.Password))
                throw new WrongPasswordException();
            
            return new ValidateUserResponse()
                { Email = user.Email, Name = user.Name, Surname = user.Surname, UserID = user.UserID };
        }
    }
}