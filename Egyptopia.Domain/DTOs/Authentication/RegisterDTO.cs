using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Domain.DTOs.Authentication
{
    public record RegisterDTO
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Country { get; init; }
        public DateOnly DOB { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }
        public string Role { get; init; }

    }
}
