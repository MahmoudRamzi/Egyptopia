using Egyptopia.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Userexperience
{
    public class WriteUserExperience
    {
        [Required]
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
