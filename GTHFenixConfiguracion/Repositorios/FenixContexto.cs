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
        public DbSet<CausaAusentismo> causaAusentismos { get; set; }
        public DbSet<CausaIncapacidad> CausaIncapacidad { get; set; }
        public DbSet<RetiroCausa> RetirosCausa { get; set; }
        public DbSet<RetiroCategoria> RetiroCategorias { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LicenciaRemuneradaCausaModelBuilder());
            modelBuilder.ApplyConfiguration(new CausaAusentismoModelBuilder());
            modelBuilder.ApplyConfiguration(new CausaIncapacidadModelBuilder());
            modelBuilder.ApplyConfiguration(new RetiroCausaModelBuilder());
            modelBuilder.ApplyConfiguration(new RetiroCategoriaModelBuilder());
            modelBuilder.ApplyConfiguration(new ItemModelBuilder());
        }
    }
}
