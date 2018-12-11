using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTHFenixConfiguracion.Repositorios.ModelBuilders
{
    internal class CausaAusentismoModelBuilder : IEntityTypeConfiguration<CausaAusentismo>
    {
        public void Configure(EntityTypeBuilder<CausaAusentismo> entity)
        {
            entity.ToTable("CausasAusentismos", "FNX_GTH");
            entity.HasKey(propiedad => propiedad.Id);
            entity.Property(propiedad => propiedad.Descripcion).HasColumnType("VARCHAR(50)").HasMaxLength(50);
            entity.Property(propiedad => propiedad.IdItem).HasColumnType("VARCHAR(10)").HasMaxLength(10);
            entity.Property(propiedad => propiedad.Remunerado).HasColumnType("VARCHAR(2)").HasMaxLength(2);
        }
    }
}