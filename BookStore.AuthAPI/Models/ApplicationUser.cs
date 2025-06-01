using Microsoft.AspNetCore.Identity;

namespace BookStore.AuthAPI.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
