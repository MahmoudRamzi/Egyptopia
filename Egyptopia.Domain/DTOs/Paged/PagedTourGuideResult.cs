using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.DTOs.TourGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Paged
{
    public class PagedTourGuideResult
    {
        public List<ReadTourGuide> tourGuides { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
