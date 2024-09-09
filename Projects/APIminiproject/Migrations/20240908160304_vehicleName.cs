using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIminiproject.Migrations
{
    /// <inheritdoc />
    public partial class vehicleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleName",
                table: "Vehicles");
        }
    }
}
