namespace UrlShortener.Api.Models.Shortener;

public class Url
{
    public Guid Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTimeOffset CreateDateTimeUtc { get; set; }
}
