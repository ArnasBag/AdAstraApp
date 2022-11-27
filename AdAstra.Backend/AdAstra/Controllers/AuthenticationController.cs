using AdAstra.DataAccess.Entities;
using AdAstra.Dtos;
using AdAstra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IAuthService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto request)
        {
            await _authenticationService.RegisterAsync(request);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto request)
        {
            var response = await _authenticationService.LoginAsync(request);
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(Token token)
        {
            var newToken = await _tokenService.RefreshToken(token);
            return Ok(newToken);
        }
    }
}
