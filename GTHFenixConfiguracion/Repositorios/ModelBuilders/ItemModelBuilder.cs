using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GTHFenixConfiguracion.Repositorios
{
    internal class ItemModelBuilder : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entity)
        {
            ValueConverter aMayusculas = new ValueConverter<string, string>(
                valor => valor.ToUpper(),
                valor => valor.ToUpper()
            );

            entity.ToTable("Items", "FNX_GTH").HasKey(propiedad => propiedad.ItmId);
            entity.Property(propiedad => propiedad.ItmId).HasColumnType("VARCHAR(10)").HasMaxLength(10).HasConversion(aMayusculas);
            entity.Property(propiedad => propiedad.Descripcion).HasColumnType("VARCHAR(50)").HasMaxLength(50);
        }
    }
}