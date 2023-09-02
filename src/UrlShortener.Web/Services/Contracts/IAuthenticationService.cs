using UrlShortener.Shared.Dtos.Identity;

namespace UrlShortener.Web.Services.Contracts;

public interface IAuthenticationService
{
    Task SignIn(SignInRequestDto dto);

    Task SignOut();
}
