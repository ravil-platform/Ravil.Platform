namespace Persistence.Entities.ShortLink.Repositories;

public class ShortLinkRepository : Repository<Domain.Entities.ShortLink.ShortLink>, IShortLinkRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal ShortLinkRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }


    public async Task<string> GenerateShortLink(int? length, ShortLinkType type)
    {
        length ??= 5;
        string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length.Value);

        while (await ApplicationDbContext.ShortLink.AnyAsync(a => a.ShortKey.Equals(key)))
        {
            key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length.Value);
        }
        return key;
    }

    public Task<string> EncodePersianLink(string text)
    {
        if (text.Contains('-') || text.Contains("-"))
        {
            text = text.Trim().Replace('-', ' ');
        }
        return Task.FromResult(text.Trim().Replace(' ', '-'));
    }

    public Task<string> DecodePersianLink(string text)
    {
        return Task.FromResult(text.Trim().Replace('-', ' '));
    }
}