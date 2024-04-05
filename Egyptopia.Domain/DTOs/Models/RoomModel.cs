using Egyptopia.Domain.Entities;
using System;

namespace EgyptopiaApi.Models
{
    public class RoomModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? RoomType { get; set; }

        public string? Description { get; set; }
        public int NumberFrom { get; set; }
        public int NumberTo { get; set; }
        public int RoomCount { get; set; }
        public double Price { get; set; }
        public Guid? HotelId { get; set; }

     
    }
}
