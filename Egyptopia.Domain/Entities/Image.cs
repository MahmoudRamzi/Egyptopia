
using Egyptopia.Domain.Common;
using Egyptopia.Domain.Enums;

namespace Egyptopia.Domain.Entities
{
    public class Image : IEntityBase

    {
        //public string? Name { get; set; }
        public string? Description { get; set; }

        //public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EntityId { get; set; }
        public ImageEntity ImageEntity {get; set;}

        
    




    }
}
