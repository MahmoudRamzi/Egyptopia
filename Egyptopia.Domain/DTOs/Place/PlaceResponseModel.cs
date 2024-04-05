using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.Enums;
using EgyptopiaApi.Models;
using System;
using System.Collections.Generic;

namespace Egyptopia.Domain.DTOs.Place
{
    public class PlaceResponseModel
    {
        public string Description { get; set; }
        public PlaceType PlaceType { get; set; }
        public string Location { get; set; }
        public Guid Id { get; set; }
        public Guid GovernorateId { get; set; }
        public List<ImagDTO> Images { get; set; }
        public string Name { get; set; }
        public string GovernorateName { get; set; }
    }
}
