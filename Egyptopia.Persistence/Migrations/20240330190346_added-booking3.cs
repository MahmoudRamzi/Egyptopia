using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedbooking3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Rooms_RoomId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_TourGuids_TourGuideId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CodeFrom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CodeTo",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Bookings",
                newName: "CheckOutDate");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TourGuideId",
                table: "Bookings",
                newName: "IX_Bookings_TourGuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomId",
                table: "Bookings",
                newName: "IX_Bookings_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "NumberFrom",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberTo",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TourGuids_TourGuideId",
                table: "Bookings",
                column: "TourGuideId",
                principalTable: "TourGuids",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TourGuids_TourGuideId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberFrom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberTo",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Booking",
                newName: "CheckOut");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TourGuideId",
                table: "Booking",
                newName: "IX_Booking_TourGuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomId",
                table: "Booking",
                newName: "IX_Booking_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "CodeFrom",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeTo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Rooms_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_TourGuids_TourGuideId",
                table: "Booking",
                column: "TourGuideId",
                principalTable: "TourGuids",
                principalColumn: "Id");
        }
    }
}
