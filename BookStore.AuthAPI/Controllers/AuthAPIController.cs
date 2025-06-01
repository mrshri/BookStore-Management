using BookStore.AuthAPI.Models.DTO;
using BookStore.AuthAPI.Services.Iservice;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(new { message = errorMessage });
            }

            return Ok(new { message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var logingResponse = await _authService.Login(model);
            if (logingResponse.User == null) {
                return BadRequest(new { message = logingResponse });
            }

            return Ok(logingResponse);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email,model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                return BadRequest(new { message = "Error Encountered" });
            }

            return Ok(assignRoleSuccessful);
        }
    }
}
