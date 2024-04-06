using Egyptopia.Domain.DTOs.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Userexperience
{
    public class ReadUserExperience
    {
        public string Description { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string PersonalImageName {  get; set; }
        public string ExperinceImageName { get; set; }
    }
}
