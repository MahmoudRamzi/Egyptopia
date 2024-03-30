using System;

namespace EgyptopiaApi.Models
{
    public class RoomModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? RoomType { get; set; }

        
        public string? CodeFrom { get; set; }
        public string? CodeTo { get; set; }
        public double Price { get; set; }
        public Guid? HotelId { get; set; }
    }
}
