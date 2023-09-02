namespace UrlShortener.Shared.Services.Contracts;

public interface IAuthTokenProvider
{
    Task<string?> GetAccessTokenAsync();
}
