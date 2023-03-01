using Meridia.Application.Models.DTOs;
using Meridia.Domain.Entities.Users;

namespace Meridia.Application.Interfaces;

public interface ITokenService
{
    Token CreateAccessToken(int second, Users user);
    string CreateRefreshToken();
}