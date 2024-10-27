namespace Application.Contracts.Identity
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(ApplicationUser user);
    }
}