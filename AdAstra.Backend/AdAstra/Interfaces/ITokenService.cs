using AdAstra.DataAccess.Entities;

namespace AdAstra.Interfaces
{
    public interface ITokenService
    {
        Task<Token> GetTokenAsync(ApplicationUser user);
        Task<Token> RefreshToken(Token token);
    }
}
