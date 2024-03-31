using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenGovAndHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GovernorateId",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_GovernorateId",
                table: "Hotels",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Governorates_GovernorateId",
                table: "Hotels",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Governorates_GovernorateId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_GovernorateId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Hotels");
        }
    }
}
