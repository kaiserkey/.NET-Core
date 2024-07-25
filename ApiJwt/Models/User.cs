using Microsoft.AspNetCore.Identity;

namespace ApiJwt.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
