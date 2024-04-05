using Egyptopia.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EgyptopiaApi.Models
{
    public class BookingModel
    {
        public DateTime BookingDate { get; set; } // Date of booking
        public DateTime CheckInDate { get; set; }

        public Guid Id { get; set; }= Guid.NewGuid();
        public DateTime CheckOutDate { get; set; }
        public Guid? TourGuideId { get; set; }
        
        public int RoomNumber { get; set; }

        // Foreign key for Room (nullable)
        public Guid? RoomId { get; set; }
     
      
        public decimal TotalAmount { get; set; }
    }
}
