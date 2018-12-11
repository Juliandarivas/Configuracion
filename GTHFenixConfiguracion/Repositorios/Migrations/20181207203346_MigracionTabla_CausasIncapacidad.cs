using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTHFenixConfiguracion.Repositorios.Migrations
{
    public partial class MigracionTabla_CausasIncapacidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CausasIncapacidades",
                schema: "FNX_GTH",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricpcion = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    MesesPromedio = table.Column<int>(nullable: false),
                    PorcentajeEmpleador = table.Column<double>(type: "FLOAT", nullable: false),
                    PorcentajeEntidad = table.Column<double>(type: "FLOAT", nullable: false),
                    DiasEmpleador = table.Column<int>(nullable: false),
                    DiasMaximos = table.Column<int>(nullable: false),
                    TipoConteoDias = table.Column<byte>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Entidad = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausasIncapacidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CausasIncapacidades",
                schema: "FNX_GTH");
        }
    }
}
