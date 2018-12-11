using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTHFenixConfiguracion.Repositorios.Migrations
{
    public partial class MigracionTabla_RetirosCausas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "RetirosCausas",
            schema: "FNX_GTH",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Descripcion = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                IdRetiroCategoria = table.Column<int>(nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirosCausas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetirosCausas_RetirosCategorias_IdRetiroCategoria",
                        column: x => x.IdRetiroCategoria,
                        principalSchema: "FNX_GTH",
                        principalTable: "RetirosCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetirosCausas_IdRetiroCategoria",
                schema: "FNX_GTH",
                table: "RetirosCausas",
                column: "IdRetiroCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "RetirosCausas",
            schema: "FNX_GTH");
        }
    }
}
