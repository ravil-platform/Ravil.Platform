using Enums;

namespace Persistence.Entities.ShortLink.Repositories
{
    public interface IShortLinkRepository : IRepository<Domain.Entities.ShortLink.ShortLink>
    {
        Task<string> GenerateShortLink(int? length, ShortLinkType type);
        Task<string> EncodePersianLink(string text);
        Task<string> DecodePersianLink(string text);
    }
}