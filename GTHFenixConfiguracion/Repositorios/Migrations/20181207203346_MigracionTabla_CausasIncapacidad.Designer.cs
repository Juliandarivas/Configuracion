﻿// <auto-generated />
using GTHFenixConfiguracion.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GTHFenixConfiguracion.Repositorios.Migrations
{
    [DbContext(typeof(FenixContexto))]
    [Migration("20181207203346_MigracionTabla_CausasIncapacidad")]
    partial class MigracionTabla_CausasIncapacidad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.CausaAusentismo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("DescuentaDomingo");

                    b.Property<string>("IdItem")
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Remunerado")
                        .HasColumnType("VARCHAR(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("CausasAusentismos","FNX_GTH");
                });

            modelBuilder.Entity("Entidades.CausaIncapacidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descricpcion")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("DiasEmpleador");

                    b.Property<int>("DiasMaximos");

                    b.Property<string>("Entidad")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3);

                    b.Property<int>("MesesPromedio");

                    b.Property<double>("PorcentajeEmpleador")
                        .HasColumnType("FLOAT");

                    b.Property<double>("PorcentajeEntidad")
                        .HasColumnType("FLOAT");

                    b.Property<byte>("TipoConteoDias");

                    b.HasKey("Id");

                    b.ToTable("CausasIncapacidades","FNX_GTH");
                });

            modelBuilder.Entity("Entidades.LicenciaRemuneradaCausa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IdItem")
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("LicenciasRemuneradasCausas","FNX_GTH");
                });
#pragma warning restore 612, 618
        }
    }
}
