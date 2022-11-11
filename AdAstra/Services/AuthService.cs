using AdAstra.DataAccess.Constants;
using AdAstra.DataAccess.Entities;
using AdAstra.Dtos;
using AdAstra.Exceptions;
using AdAstra.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace AdAstra.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<SuccessfulLoginDto> LoginAsync(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if(user == null)
            {
                throw new ValidationException("Invalid login data!");
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (!passwordValid)
            {
                throw new ValidationException("Invalid login data!");
            }

            var accessToken =  await _tokenService.GetTokenAsync(user);

            return new SuccessfulLoginDto() { Token = accessToken.AccessToken, RefreshToken = accessToken.RefreshToken };
        }

        public async Task RegisterAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerUserDto.Email);

            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("User with this email already exists!");
            }

            var newUser = _mapper.Map<ApplicationUser>(registerUserDto);

            var result = await _userManager.CreateAsync(newUser, registerUserDto.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(string.Join(" ", result.Errors.Select(e => e.Description)));
            }

            await _userManager.AddToRoleAsync(newUser, Authorization.Roles.User.ToString());
        }
    }
}
