using Egyptopia.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Egyptopia.Domain.DTOs.TourGuide;

namespace EgyptopiaApi.Models
{
    public class BookingTourGuideResponseModel
    {
        public DateTime CheckInDate { get; set; }


        public Guid Id { get; set; }

        public int NumberOfGuests { get; set; } = 1;

        public TourGuideModell TourGuide { get; set; }   
        public double TotalAmount { get; set; }
    }
}
