using System.IdentityModel.Tokens.Jwt;
using Selection_Register.modelo;

namespace Selection_Register.Services
{
    public interface ITokenService
    {
         JwtSecurityToken GenerateJWTToken(Credenciado user);
    }
}