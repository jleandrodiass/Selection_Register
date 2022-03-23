using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Selection_Register.modelo;

namespace Selection_Register.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Credenciado credenciado )
        {
            var tokenH = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(ValidT.Secret);
              var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(  ClaimTypes.Name, credenciado.Nome.ToString()),
                    new Claim(ClaimTypes.Role, credenciado.Cargo.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(8),
                 SigningCredentials = 
                  new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
                var token = tokenH.CreateToken(tokenDescriptor);
                 return tokenH.WriteToken(token);
        }
    }
}