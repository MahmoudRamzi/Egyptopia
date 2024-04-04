using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedplacetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceType",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceType",
                table: "Places");
        }
    }
}
