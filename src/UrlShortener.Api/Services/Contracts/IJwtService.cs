using UrlShortener.Api.Models.Identity;
using UrlShortener.Shared.Dtos.Identity;

namespace UrlShortener.Api.Services.Contracts;

public interface IJwtService
{
    Task<SignInResponseDto> GenerateToken(User user);
}
