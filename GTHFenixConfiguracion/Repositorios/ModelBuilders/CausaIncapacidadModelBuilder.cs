using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTHFenixConfiguracion.Repositorios.ModelBuilders
{
    internal class CausaIncapacidadModelBuilder : IEntityTypeConfiguration<CausaIncapacidad>
    {
        public void Configure(EntityTypeBuilder<CausaIncapacidad> entity)
        {
            entity.ToTable("CausasIncapacidades", "FNX_GTH");
            entity.HasKey(propiedad => propiedad.Id);
            entity.Property(propiedad => propiedad.Descricpcion).HasColumnType("VARCHAR(50)").HasMaxLength(50);
            entity.Property(propiedad => propiedad.Entidad).HasColumnType("VARCHAR(3)").HasMaxLength(3);
            entity.Property(propiedad => propiedad.PorcentajeEmpleador).HasColumnType("FLOAT");
            entity.Property(propiedad => propiedad.PorcentajeEntidad).HasColumnType("FLOAT");
        }
    }
}