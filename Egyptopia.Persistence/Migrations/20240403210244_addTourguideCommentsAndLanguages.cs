using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTourguideCommentsAndLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "TourGuids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutInfo",
                table: "TourGuids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TourGuids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourGuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuideComments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideComments_TourGuids_TourGuideId",
                        column: x => x.TourGuideId,
                        principalTable: "TourGuids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideLanguages",
                columns: table => new
                {
                    TourGuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideLanguages", x => new { x.TourGuideId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_TourGuideLanguages_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideLanguages_TourGuids_TourGuideId",
                        column: x => x.TourGuideId,
                        principalTable: "TourGuids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideComments_ApplicationUserId",
                table: "TourGuideComments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideComments_TourGuideId",
                table: "TourGuideComments",
                column: "TourGuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideLanguages_LanguageId",
                table: "TourGuideLanguages",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourGuideComments");

            migrationBuilder.DropTable(
                name: "TourGuideLanguages");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropColumn(
                name: "AboutInfo",
                table: "TourGuids");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TourGuids");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "TourGuids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
