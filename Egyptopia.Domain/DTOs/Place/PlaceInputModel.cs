using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using EgyptopiaApi.Models;
using System;

namespace Egyptopia.Domain.DTOs.Place
{
    public class PlaceInputModel
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public Guid GovernorateId { get; set; }
        public PlaceType PlaceType { get; set; }
        public string Name { get; set; }
    }
}
