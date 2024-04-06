using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Governorate : EntityBase
    {
        //public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }
        //public ICollection<Hotel> Hotels { get; set; }
    }
}