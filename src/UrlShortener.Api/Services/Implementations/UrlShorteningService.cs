namespace UrlShortener.Api.Services.Implementations;

public class UrlShorteningService
{
    public const int SHORTEN_URL_LENGTH = 7;

    private const string CHARS_POOL = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random _random = new();
    private readonly AppDbContext _dbContext;

    public UrlShorteningService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> GenerateCode()
    {
        var codeChars = new char[SHORTEN_URL_LENGTH];

        while (true)
        {
            for (int i = 0; i < SHORTEN_URL_LENGTH; i++)
            {
                var idx = _random.Next(CHARS_POOL.Length - 1);

                codeChars[i] = CHARS_POOL[idx];
            }

            string code = new string(codeChars);

            if (await _dbContext.Urls.AnyAsync(u => u.Code == code) is false)
            {
                return code;
            }
        }
    }

}
