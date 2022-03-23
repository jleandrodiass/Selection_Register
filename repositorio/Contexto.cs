using Microsoft.EntityFrameworkCore;
using Selection_Register.modelo;

namespace Selection_Register.repositorio
{
    public partial class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
            :base (options)
        {
        }

        public virtual DbSet<Credenciado> Credenciado{get; set; }
        public virtual DbSet<Info_Candidato> Info_Candidato{get; set; }
        public virtual DbSet<UploadArquivos> UploadArquivos{get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(! optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Selection_Register;Data Source=DESKTOP-321DA7H\\SQLEXPRESS");
            }
        }
    }
}