using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.Entities;
using System;

namespace EgyptopiaApi.Models
{
    public class FacilityModel
    {
        public Guid Id { get; set; }
        public string Name;
        public Guid HotelId { get; set; }

        public virtual ReadHotel Hotel { get; set; }
    }
}
