using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class TourGuideLanguage
    {
        public Guid TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
