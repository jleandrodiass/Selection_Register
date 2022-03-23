using Microsoft.AspNetCore.Mvc;
using Selection_Register.modelo;
using Selection_Register.repositorio;

namespace Selection_Register.business
{
     public class CandidatoBs : Response
     {
         public Info_Candidato Post(Info_Candidato novoCandidato)
         {
              var candidatoBs = new CandidatoRp();
               var candidato = candidatoBs.Post(novoCandidato);
                return candidato;
         }
        public List<Info_Candidato> GetAll()
        {
             var candidatoBs = new CandidatoRp();
               var list = candidatoBs.GetAll();
                return list;
        }
        public ActionResult Delete(int id)
        {
             var candidatoBs = new CandidatoRp();
               var removeCand = candidatoBs.Delete(id);
                return NoContent();
        }
    }
}