using Egyptopia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class Facility:EntityBase
    {
        public string Name;
        public Guid HotelId { get; set; }
        
        public virtual Hotel Hotel { get; set; }

    }
}
