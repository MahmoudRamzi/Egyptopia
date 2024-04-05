using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptopiaApi.Models
{
    public class GovernorateModel
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
