using Egyptopia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.Entities
{
    public class Place:IEntityBase
    {
        
        public Guid Id { get; set; }= Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid GovernorateId {  get; set; }
  
        public virtual Governorate? Governorate { get; set; }



       


    }
}
