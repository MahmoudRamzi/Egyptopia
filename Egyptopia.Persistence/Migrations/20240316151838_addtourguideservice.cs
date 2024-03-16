using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtourguideservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TourGuids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TourGuideServices",
                columns: table => new
                {
                    TourGuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServices", x => new { x.TourGuideId, x.PlaceId });
                    table.ForeignKey(
                        name: "FK_TourGuideServices_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideServices_TourGuids_TourGuideId",
                        column: x => x.TourGuideId,
                        principalTable: "TourGuids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServices_PlaceId",
                table: "TourGuideServices",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourGuideServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TourGuids");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hotels");
        }
    }
}
