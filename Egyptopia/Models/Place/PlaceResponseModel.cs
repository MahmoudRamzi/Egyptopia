using Egyptopia.Domain.Enums;
using System;

namespace EgyptopiaApi.Models.Place
{
    public class PlaceResponseModel
    {
        public string? Description { get; set; }
        public string? Location { get; set; }

        public Guid GovernorateId { get; set; }
        public PlaceType PlaceType { get; set; }
        
    }
}
