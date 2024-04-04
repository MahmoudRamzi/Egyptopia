using Egyptopia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class TourGuideComment:EntityBase
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateOnly PublishedDate { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }
    }
}
