using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTHFenixConfiguracion.Repositorios.ModelBuilders
{
    internal class RetiroCausaModelBuilder : IEntityTypeConfiguration<RetiroCausa>
    {
        public void Configure(EntityTypeBuilder<RetiroCausa> entity)
        {
            entity.ToTable("RetirosCausas", "FNX_GTH");
            entity.HasKey(propiedad => propiedad.Id);
            entity.Property(propiedad => propiedad.Descripcion)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50);
        }
    }
}
