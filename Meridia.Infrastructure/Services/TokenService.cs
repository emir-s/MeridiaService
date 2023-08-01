using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Meridia.Application.Interfaces;
using Meridia.Application.Models.DTOs;
using Meridia.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Meridia.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Token CreateAccessToken(int minute, Users user)
    {
        Token token = new();
        
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        //Şifrelenmiş kimliği oluşturuyoruz.
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        //Oluşturulacak token ayarlarını veriyoruz.
        token.Expiration = DateTime.UtcNow.AddMinutes(minute);
        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims: new List<Claim> { new(ClaimTypes.Email, user.Email) }
        );
        
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);
        
        token.RefreshToken = CreateRefreshToken();
        
        return token;
    }

    
    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}