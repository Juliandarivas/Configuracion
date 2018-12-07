using Entidades;
using GTHFenixConfiguracion.Repositorios.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace GTHFenixConfiguracion.Repositorios
{
    public class FenixContexto : DbContext
    {
        public FenixContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LicenciaRemuneradaCausa> LicenciaRemuneradaCausas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LicenciaRemuneradaCausaModelBuilder());
        }
    }
}
