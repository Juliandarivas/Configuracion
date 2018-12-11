using Microsoft.EntityFrameworkCore.Migrations;

namespace GTHFenixConfiguracion.Repositorios.Migrations
{
    public partial class Migracion_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                schema: "FNX_GTH",
                columns: table => new
                {
                    ItmId = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Nomina = table.Column<byte>(nullable: true),
                    Factor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItmId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items",
                schema: "FNX_GTH");
        }
    }
}
