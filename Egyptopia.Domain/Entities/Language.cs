using Egyptopia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class Language:EntityBase
    {
        public ICollection<TourGuideLanguage> TourGuideLanguages { get; set; }
    }
}
