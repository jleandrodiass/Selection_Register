using Microsoft.AspNetCore.Mvc;
using Selection_Register.business;
using Selection_Register.modelo;

namespace Selection_Register.repositorio
{
    public class CandidatoRp : Response
    {
        public Info_Candidato Post(Info_Candidato novoCandidato)
        { 
             using (var db = new repositorio.Contexto())
            {
                db.Info_Candidato.Add(novoCandidato);
                 db.SaveChanges();
                  return novoCandidato;
            }
        }
         public List<Info_Candidato> GetAll()
        {
            using (var db = new repositorio.Contexto())
            {
                List<Info_Candidato> lista = db.Info_Candidato.ToList();
                 return lista;
            }
        }
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