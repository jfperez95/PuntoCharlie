using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Puntocharlie.Migrations
{
    /// <inheritdoc />
    public partial class nuevoCampoEnPuntoServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "abreDomingo",
                table: "PuntoServicios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "abreDomingo",
                table: "PuntoServicios");
        }
    }
}
