using Microsoft.AspNetCore.Identity;

namespace Academy_Group_Management.Models.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

    }
}
