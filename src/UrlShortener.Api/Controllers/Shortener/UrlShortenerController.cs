using UrlShortener.Api.Models.Shortener;
using UrlShortener.Api.Services.Implementations;
using UrlShortener.Shared.Dtos.Shortener;

namespace UrlShortener.Api.Controllers.Shortener;

[ApiController]
[AllowAnonymous]
public partial class UrlShortenerController : AppControllerBase
{
    [AutoInject] private IHttpContextAccessor _httpContextAccessor = default!;
    [AutoInject] private UrlShorteningService _urlShortenningService = default!;

    [HttpPost("api/shorten")]
    public async Task<IResult> Post(ShortenUrlRequest request, CancellationToken cancellationToken)
    {
        if (Uri.TryCreate(request.Url, UriKind.Absolute, out _) is false)
        {
            return Results.BadRequest("The URL is invalid.");
        }

        var code = await _urlShortenningService.GenerateCode();
        var url = new Url
        {
            Id = Guid.NewGuid(),
            LongUrl = request.Url,
            Code = code,
            ShortUrl = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext!.Request.Host}/api/{code}",
            CreateDateTimeUtc = DateTimeOffset.UtcNow
        };

        DbContext.Urls.Add(url);
        await DbContext.SaveChangesAsync();

        return Results.Ok(url.ShortUrl);
    }

    [HttpGet("api/{code}")]
    public async Task<IResult> Get(string code)
    {
        var url = await DbContext.Urls.FirstOrDefaultAsync(u => u.Code == code);

        if (url is null)
        {
            return Results.NotFound();
        }

        return Results.Redirect(url.LongUrl);
    }
}
