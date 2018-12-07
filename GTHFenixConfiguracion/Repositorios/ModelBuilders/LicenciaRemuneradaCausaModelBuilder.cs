using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTHFenixConfiguracion.Repositorios.ModelBuilders
{
    public class LicenciaRemuneradaCausaModelBuilder : IEntityTypeConfiguration<LicenciaRemuneradaCausa>
    {
        public void Configure(EntityTypeBuilder<LicenciaRemuneradaCausa> entity)
        {
            entity.ToTable("LicenciasRemuneradasCausas", "FNX_GTH");
            entity.HasKey(propiedad => propiedad.Id);
            entity.Property(propiedad => propiedad.Descripcion).HasColumnType("VARCHAR(50)").HasMaxLength(50);
            entity.Property(propiedad => propiedad.IdItem).HasColumnType("VARCHAR(10)").HasMaxLength(10);
        }
    }
}
