using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.DTOs.TourguideLanuage;
using Egyptopia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.TourGuide
{
    public class ReadTourGuide
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public string TotalReviews { get; set; }
        public string Location { get; set; }
        public string AboutInfo { get; set; }
        public List<TourGuideCommentDTO> Comments { get; set; }
        public List<TourGuideLanguageDTO> Languages { get; set; }
    }
}
