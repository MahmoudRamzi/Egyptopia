using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptopiaApi.Models
{
    public class GovernorateModel
    {
        public Guid Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Description { get; set; }
    }
}
