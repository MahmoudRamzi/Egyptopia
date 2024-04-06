using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EgyptopiaApi.Models.Place
{
    public class PlaceResponseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        public Guid GovernorateId { get; set; }
        public PlaceType PlaceType { get; set; }
        
    }
}
