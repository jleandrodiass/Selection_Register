using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selection_Register.Dtomodel;
using Selection_Register.repositorio;
using Selection_Register.Services;

namespace Selection_Register.modelo.Controllers
{ 

    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class GeradorTkController : ControllerBase
    {
        private readonly ITokenService _token;

        public GeradorTkController(ITokenService token)
        {
            _token = token;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] CredenciadoDto credenciadoDto)
        {
           
            if(string.IsNullOrEmpty(credenciadoDto?.Login) || string.IsNullOrEmpty(credenciadoDto?.Senha)) 
            {
                return BadRequest(new{message ="Login e Senha sao obrigatorios!"});
            }
            
            var adminRp = new AdminRp();
        
           
            var user = adminRp.Login(credenciadoDto.Login, credenciadoDto.Senha);

            if(user == null)
            {
                return Unauthorized(new{message = "Usuario ou senha invalidos"});
            }
            var token  = _token.GenerateJWTToken(user);
             
            var result  = new { accessToken = new JwtSecurityTokenHandler().WriteToken(token), Usuario = new { user.Login, user.Nome, user.Cargo }};

            return Ok(result);
        }
     
    }
}