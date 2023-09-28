using api_portaria.Model;
using Microsoft.EntityFrameworkCore;

namespace api_portaria.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<EntradaModel> Entrada { get; set; }
        public DbSet<ResponsavelModel> Responsavel { get; set; }
        public DbSet<PrimeiroResponsavelEntradaModel> PrimeiroResponsavel { get; set; }
        public DbSet<SegundoResponsavelEntradaModel> SegundoResponsavel { get; set; }
    }
}
