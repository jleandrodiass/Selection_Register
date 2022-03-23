using Selection_Register.modelo;
using Microsoft.AspNetCore.Mvc;

namespace Selection_Register.repositorio
{
    public class AdminRp 
  {
    public Credenciado Login(string login, string senha)
    {
      using (var db = new repositorio.Contexto())
      {
        
        Credenciado loginadmin = db.Credenciado.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        return loginadmin;
      }
    } 
    public Credenciado Add(Credenciado novoCredenciado)
    {
        using (var db = new repositorio.Contexto())
        {
          db.Credenciado.Add(novoCredenciado);
          db.SaveChanges();
          return novoCredenciado;
        }
    }
  }
}