

namespace Egyptopia.Domain.Common
{
    /// <summary>
    /// change to normal class
    /// </summary>
    public class IEntityBase
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }

    }
}
