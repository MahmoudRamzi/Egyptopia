using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedbooking2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Booking");
        }
    }
}
