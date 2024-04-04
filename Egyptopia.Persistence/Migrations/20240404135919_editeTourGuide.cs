using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editeTourGuide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "TourGuids",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TourGuids",
                newName: "Rating");
        }
    }
}
