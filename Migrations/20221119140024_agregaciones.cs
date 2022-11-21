using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformeTorneo.Migrations
{
    /// <inheritdoc />
    public partial class agregaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantEquipos",
                table: "Torneos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantEquipos",
                table: "Torneos");
        }
    }
}
