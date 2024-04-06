using Egyptopia.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptopia.Domain.Entities
{
    public class Hotel : EntityBase
    {
        //public Guid Id { get; set; }=new Guid();
        public string? Name;

        public string Description { get; set; }
        public string Location { get; set; }
        //[ForeignKey("Governorate")]
        //public Guid GovernorateId { get; set; }
        //public virtual Governorate Governorate { get; set; }

        public List<HotelComment> HotelComments { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}