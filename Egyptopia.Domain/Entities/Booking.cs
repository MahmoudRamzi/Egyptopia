using Egyptopia.Domain.Common;
using Egyptopia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class Booking:EntityBase
    {
        

        public DateTime BookingDate { get; set; } // Date of booking
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        //public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? TourGuideId { get; set; }
        [ForeignKey("TourGuideId")]
        public virtual TourGuide TourGuide { get; set; }

        // Foreign key for Room (nullable)
        public Guid? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public int RoomNumber { get; set; }
        public double TotalAmount { get; set; }


    }
}
