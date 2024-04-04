using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class BookingTourGuide
    {
        public DateTime CheckInDate { get; set; }
        

        //public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? TourGuideId { get; set; }
        [ForeignKey("TourGuideId")]
        public virtual TourGuide TourGuide { get; set; }
        public double TotalAmount { get; set; }
    }
}
