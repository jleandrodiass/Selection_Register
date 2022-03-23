using Microsoft.AspNetCore.Mvc;
using Selection_Register.modelo;
using Selection_Register.repositorio;

namespace Selection_Register.Controllers
{
    public class AdministradoresController : ControllerBase
    {
            [HttpPost("Add")]
        public ActionResult Post(Credenciado novoCredenciado)
        {
            var adminRp = new AdminRp();
             var addCredenciado = adminRp.Add(novoCredenciado);
              return Ok(addCredenciado);
            
            
        }    
         [HttpGet]
        public List<Credenciado> Get()
        {
            using (var db = new repositorio.Contexto())
            {
                List<Credenciado> lista = db.Credenciado.ToList();
                return lista;
            }
        }    
    }
}