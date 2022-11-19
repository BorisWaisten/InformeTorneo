using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformeTorneo.Migrations
{
    /// <inheritdoc />
    public partial class agregacionTorneo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InformeId",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    torneoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informes_Torneos_torneoNombre",
                        column: x => x.torneoNombre,
                        principalTable: "Torneos",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_InformeId",
                table: "Equipos",
                column: "InformeId");

            migrationBuilder.CreateIndex(
                name: "IX_Informes_torneoNombre",
                table: "Informes",
                column: "torneoNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Informes_InformeId",
                table: "Equipos",
                column: "InformeId",
                principalTable: "Informes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Informes_InformeId",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_InformeId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "InformeId",
                table: "Equipos");
        }
    }
}
