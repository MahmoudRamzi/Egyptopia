using Egyptopia.Domain.DTOs.HotelComment;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Hotel
{
    public class ReadHotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<HotelCommentDTO> Comments { get; set; }
        public List<ImagDTO> Images { get; set; }
        public int Rate { get; set; }
        
    }
}
