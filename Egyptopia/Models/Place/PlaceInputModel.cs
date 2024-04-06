using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using System;

namespace EgyptopiaApi.Models.Place
{
    public class PlaceInputModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public PlaceType PlaceType { get; set; }
        public string? Location { get; set; }
        //public Guid GovernorateId { get; set; }
        public Guid Id { get; set; }
        public GovernorateModel? Governorate { get; set; }
    }
}
