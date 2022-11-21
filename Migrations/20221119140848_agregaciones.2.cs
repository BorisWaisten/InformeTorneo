using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformeTorneo.Migrations
{
    /// <inheritdoc />
    public partial class agregaciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TorneoNombre",
                table: "Equipos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TorneoNombre",
                table: "Equipos",
                column: "TorneoNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Torneos_TorneoNombre",
                table: "Equipos",
                column: "TorneoNombre",
                principalTable: "Torneos",
                principalColumn: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Torneos_TorneoNombre",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_TorneoNombre",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "TorneoNombre",
                table: "Equipos");
        }
    }
}
