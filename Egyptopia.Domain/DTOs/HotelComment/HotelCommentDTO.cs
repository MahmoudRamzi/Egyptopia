using Egyptopia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.HotelComment
{
    public class HotelCommentDTO
    {
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Rating { get; set; }
    }
}
