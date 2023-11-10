using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIGerenciadorDePonto.Migrations
{
    /// <inheritdoc />
    public partial class LatitudeLongitude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "RegistrosPonto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Logintude",
                table: "RegistrosPonto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RegistrosPonto");

            migrationBuilder.DropColumn(
                name: "Logintude",
                table: "RegistrosPonto");
        }
    }
}
