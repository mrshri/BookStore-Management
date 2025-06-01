using BookStore.AuthAPI.Models.DTO;

namespace BookStore.AuthAPI.Services.Iservice
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registrationRequestDTO);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<bool> AssignRole(string email,string roleName);
    }
}
