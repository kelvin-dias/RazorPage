using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;

namespace Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() { }
        public EFContext(DbContextOptions<EFContext> options) : base(options)  {   }
        public DbSet<Ocorrencia> ocorrencias { get; set; }

    }
}
