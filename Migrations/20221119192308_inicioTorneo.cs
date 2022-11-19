using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformeTorneo.Migrations
{
    /// <inheritdoc />
    public partial class inicioTorneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    PartidosGanados = table.Column<int>(type: "int", nullable: false),
                    PartidosEmpatados = table.Column<int>(type: "int", nullable: false),
                    PartidosPerdidos = table.Column<int>(type: "int", nullable: false),
                    GolesAFavor = table.Column<int>(type: "int", nullable: false),
                    GolesEnContra = table.Column<int>(type: "int", nullable: false),
                    DiferenciaDeGoles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.Nombre);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneos");
        }
    }
}
