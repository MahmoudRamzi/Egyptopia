using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class Place : IEntityBase
    {
        //public Guid Id { get; set; }= Guid.NewGuid();
        //public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid GovernorateId { get; set; }

        public virtual Governorate? Governorate { get; set; }
    }
}