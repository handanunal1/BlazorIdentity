using Microsoft.AspNetCore.Identity;

namespace BlazorIdentity.Server.Models
{
    public class ApplicationUser : IdentityUser
    {

        public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();
    }
}