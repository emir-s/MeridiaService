namespace Meridia.Application.Interfaces.Services;

public interface ICryptService
{
    public string EncryptPassword(string Password);
    public bool DecryptPassword(string Password, string HashedPassword);
}