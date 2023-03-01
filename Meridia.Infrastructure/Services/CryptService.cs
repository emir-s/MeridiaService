using Meridia.Application.Interfaces.Services;

namespace Meridia.Infrastructure.Services;

public class CryptService: ICryptService
{
    public string EncryptPassword(string Password)
    {
       return BCrypt.Net.BCrypt.HashPassword(Password);
    }

    public bool DecryptPassword(string Password, string HashedPassword)
    {
       return BCrypt.Net.BCrypt.Verify(Password, HashedPassword);
    }
}