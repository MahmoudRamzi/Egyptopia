using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Room : IEntityBase
    {
        //public Guid Id { get; set; }= Guid.NewGuid();
        public string? RoomType { get; set; }

        public string? Description { get; set; }
        public string? CodeFrom { get; set; }
        public string? CodeTo { get; set; }
        public double Price { get; set; }
        public Guid? HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
    }
}