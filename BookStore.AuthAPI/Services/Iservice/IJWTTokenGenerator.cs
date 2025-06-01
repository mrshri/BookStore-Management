using BookStore.AuthAPI.Models;

namespace BookStore.AuthAPI.Services.Iservice
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
