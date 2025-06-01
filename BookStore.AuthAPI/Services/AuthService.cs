using BookStore.AuthAPI.DATA;
using BookStore.AuthAPI.Models;
using BookStore.AuthAPI.Models.DTO;
using BookStore.AuthAPI.Services.Iservice;
using Microsoft.AspNetCore.Identity;

namespace BookStore.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext appDbContext,UserManager<ApplicationUser> userManager
            ,RoleManager<IdentityRole> roleManager,IJWTTokenGenerator jWTTokenGenerator)
        {
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jWTTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null) {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) { 
                  //create role if already not exists
                  _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user,roleName);
                return true;            
            }
            return false;

        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user,loginRequestDTO.Password); 

            if (user == null || isValid==false)
            {
                return new LoginResponseDTO() { User = null, Token = null };
            }
            //if user found ,Generate JWT Token

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDTO uerDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDTO loginResponseDTO = new()
            {
                User = uerDto,
                Token = token
            };

            return loginResponseDTO;

        }

        public async Task<string> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new ()
            {
                UserName = registrationRequestDTO.Email,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                Name = registrationRequestDTO.Name,
                PhoneNumber = registrationRequestDTO.PhoneNumber,
            };

            try
            {
                var result = await _userManager.CreateAsync(user,registrationRequestDTO.Password);
                
                if (result.Succeeded) { 
                    var userToReturn =  _context.ApplicationUsers.First(u=>u.UserName == registrationRequestDTO.Email);

                    UserDTO userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return "Error Encountered";
        }
    }
}
