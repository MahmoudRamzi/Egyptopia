using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptopia.Domain.Entities
{
    public class TourGuideService
    {
        [ForeignKey("TourGuide")]
        public Guid TourGuideId { get; set; }

        [ForeignKey("Place")]
        public Guid PlaceId { get; set; }

        public virtual Place? Place { get; set; }
        public virtual TourGuide? TourGuide { get; set; }
    }
}