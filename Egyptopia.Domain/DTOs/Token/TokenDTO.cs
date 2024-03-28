using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Token
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
