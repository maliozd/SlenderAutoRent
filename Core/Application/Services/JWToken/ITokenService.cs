using Application.Dtos.AccessToken;
using Domain.Entites.Identity;

namespace Application.Services.JWToken
{
    public interface ITokenService
    {
        Token CreateAccessToken(int expirationMinute, AppUser user);
        string CreateRefreshToken();
    }
}
