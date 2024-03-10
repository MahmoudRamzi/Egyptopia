using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Governorate:IEntityBase
    {
         
        public Guid Id { get; set; }=Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Place>? Places { get; set; }


    }
}
