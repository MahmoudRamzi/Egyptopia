using Egyptopia.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace EgyptopiaApi.Models
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public IFormFile? File { get; set; }
        public string? Description { get; set; }

        
        public Guid EntityId { get; set; }

        public ImageEntity ImageEntity { get; set; }
    }
}
