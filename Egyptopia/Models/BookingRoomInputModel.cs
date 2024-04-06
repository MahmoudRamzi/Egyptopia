using System;

namespace EgyptopiaApi.Models
{
    public class BookingRoomInputModel
    {
        public DateTime CheckInDate { get; set; }

        //public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CheckOutDate { get; set; }


        public int RoomNumber { get; set; }

        // Foreign key for Room (nullable)
        public Guid? RoomId { get; set; }


        public decimal TotalAmount { get; set; }
    }
}
