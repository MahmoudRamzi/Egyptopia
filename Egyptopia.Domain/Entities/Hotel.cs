
using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Hotel:IEntityBase
    {
        public Guid Id { get; set; }=new Guid();
        public string? Name;

        public string? Description;
        public string? Location;
        public ICollection<Room>? Rooms { get; set; }




    }
}
