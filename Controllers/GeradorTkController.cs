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

            var token  = TokenService.GenerateToken(user);
             
            var result  = new { accessToken = token, Usuario = new { user.Login, user.Nome, user.Cargo }};

            return Ok(result);
        }
     
    }
}