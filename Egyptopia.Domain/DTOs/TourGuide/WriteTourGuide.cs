using Egyptopia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.TourGuide
{
    public class WriteTourGuide
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string AboutInfo { get; set; }
        public string IdentityNumber { get; set; }
    }
}
