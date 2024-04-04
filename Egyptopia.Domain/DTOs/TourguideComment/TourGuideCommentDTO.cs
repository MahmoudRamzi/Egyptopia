using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.TourguideComment
{
    public class TourGuideCommentDTO
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateOnly PublishedDate { get; set; }
    }
}
