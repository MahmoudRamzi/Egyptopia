using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class TourGuideService
    {
        [ForeignKey("TourGuide")]
        public Guid TourGuideId { get; set; }
        [ForeignKey("Place")]
        public Guid PlaceId { get; set; }
        public virtual Place? Place { get; set; }
        public virtual TourGuide?  TourGuide { get; set; }

    }
}
