using System;

namespace EgyptopiaApi.Models
{
    public class RoomInputModek
    {
        //public Guid Id { get; set; }
        public string? RoomType { get; set; }

        public string? Description { get; set; }
        public int NumberFrom { get; set; }
        public int NumberTo { get; set; }
        public int RoomCount { get; set; }
        public double Price { get; set; }
        public Guid? HotelId { get; set; }

    }
}
