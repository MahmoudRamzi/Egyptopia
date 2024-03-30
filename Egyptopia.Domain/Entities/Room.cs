using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Room : EntityBase
    {
        
        //enum roomtype?

        public string? RoomType { get; set; }

        public string? Description { get; set; }
        public int NumberFrom { get; set; }
        public int NumberTo { get; set; }
        public int RoomCount { get; set; }
        public double Price { get; set; }
        public Guid? HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
    }
}