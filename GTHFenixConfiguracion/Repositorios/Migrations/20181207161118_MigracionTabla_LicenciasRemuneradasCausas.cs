using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTHFenixConfiguracion.Repositorios.Migrations
{
    public partial class MigracionTabla_LicenciasRemuneradasCausas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FNX_GTH");

            migrationBuilder.CreateTable(
                name: "LicenciasRemuneradasCausas",
                schema: "FNX_GTH",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    IdItem = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenciasRemuneradasCausas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenciasRemuneradasCausas",
                schema: "FNX_GTH");
        }
    }
}
