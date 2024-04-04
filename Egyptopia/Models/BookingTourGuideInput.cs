using Egyptopia.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EgyptopiaApi.Models
{
    public class BookingTourGuideInput
    {
        public DateTime CheckInDate { get; set; }


        //public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? TourGuideId { get; set; }
        
        public double TotalAmount { get; set; }
    }
}
