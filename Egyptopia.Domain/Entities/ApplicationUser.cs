using Microsoft.AspNetCore.Identity;

namespace Egyptopia.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateOnly DOB {  get; set; }
        
    }
}