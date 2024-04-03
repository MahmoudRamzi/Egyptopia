using Egyptopia.Domain.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Paged
{
    public class PagedHotelResult
    {
        public List<ReadHotel> hotels { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
