using Egyptopia.Domain.DTOs.Hotel;
using System;

namespace EgyptopiaApi.Models
{
    public class RoomResponseModel
    {
        public Guid Id { get; set; }
        public string? RoomType { get; set; }

        public string? Description { get; set; }
        public int NumberFrom { get; set; }
        public int NumberTo { get; set; }
        public int RoomCount { get; set; }
        public double Price { get; set; }
        public ReadHotel Hotel { get; set; }
    }
}
