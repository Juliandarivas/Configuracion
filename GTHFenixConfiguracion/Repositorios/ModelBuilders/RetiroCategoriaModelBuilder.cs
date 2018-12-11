using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTHFenixConfiguracion.Repositorios
{
    internal class RetiroCategoriaModelBuilder : IEntityTypeConfiguration<RetiroCategoria>
    {
        public void Configure(EntityTypeBuilder<RetiroCategoria> entity)
        {
            entity.ToTable("RetirosCategorias", "FNX_GTH");
            entity.HasKey(propiedad => propiedad.Id);
            entity.Property(propiedad => propiedad.Descripcion);

            entity.HasMany(propiedad => propiedad.RetirosCausas)
                .WithOne(propiedad => propiedad.RetiroCategoria)
                .HasForeignKey("IdRetiroCategoria");
        }
    }
}