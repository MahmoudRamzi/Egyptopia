using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class TourGuide : EntityBase
    {
        //public Guid Id { get; set; }=Guid.NewGuid();
        //public string Name { get; set; }

        public int? Rating { get; set; }
        public string? IdentityNumber { get; set; }
        public ICollection<Place>? Places { get; set; }
    }
}