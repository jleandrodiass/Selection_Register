using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selection_Register.business;
using Selection_Register.repositorio;

namespace Selection_Register.modelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CandidatosController : ControllerBase
    {
        [HttpGet]
        public List<Info_Candidato> GetAll()
        {
             var candidatoBs = new CandidatoBs();
               var addCredenciado = candidatoBs.GetAll();
                return addCredenciado;
            
        }
        [HttpPost]
        public Info_Candidato Post(Info_Candidato novoCandidato)
        {
              var candidatoBs = new CandidatoBs();
               var addcandidato = candidatoBs.Post(novoCandidato);
                return addcandidato;
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using ( var db = new repositorio.Contexto())
            {
                var credDelet = db.Info_Candidato.Find(id);
                 db.Info_Candidato.Remove(credDelet);
                  db.SaveChanges();
                  return NoContent();
               
            }
        }
    }
}