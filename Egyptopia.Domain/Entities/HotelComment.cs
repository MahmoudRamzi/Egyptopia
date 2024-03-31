using Egyptopia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class HotelComment:EntityBase
    {
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid HotelId {  get; set; } 
        public Hotel Hotel { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Rating { get; set; }

    }
}
