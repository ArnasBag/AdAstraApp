using AdAstra.Dtos;

namespace AdAstra.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserDto registerUserDto);
        Task<SuccessfulLoginDto> LoginAsync(LoginUserDto loginUserDto);
    }
}
