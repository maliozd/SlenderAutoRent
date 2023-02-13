using Application.Dtos.AccessToken;
using Domain.Entites.Identity;

namespace Application.Abstractions.JWToken
{
    public interface ITokenService
    {
        Token CreateAccessToken(int expirationMinute, User user);
        string CreateRefreshToken();
    }
}
