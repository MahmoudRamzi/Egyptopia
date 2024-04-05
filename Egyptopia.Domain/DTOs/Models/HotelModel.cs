using System;

namespace EgyptopiaApi.Models
{
    public class HotelModel
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name;

        public string? Description;
        public string? Location;
    }
}
