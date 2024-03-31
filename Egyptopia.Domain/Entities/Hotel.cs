using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Hotel : EntityBase
    {
        //public Guid Id { get; set; }=new Guid();
        //public string? Name;

        public string Description { get; set; }
        public string Location { get; set; }
        public Guid GovernorateId { get; set; }

        public Governorate Governorate { get; set; }
        public ICollection<HotelComment> HotelComments { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}