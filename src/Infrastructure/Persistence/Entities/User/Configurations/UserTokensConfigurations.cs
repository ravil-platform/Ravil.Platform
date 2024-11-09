namespace Persistence.Entities.User.Configurations
{
    public class UserTokensConfigurations : IEntityTypeConfiguration<UserTokens>
    {
        public void Configure(EntityTypeBuilder<UserTokens> builder)
        {
            builder.ToTable("UsersToken", DatabaseSchemas.Users);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.HashJwtToken).IsRequired().HasMaxLength(MaxLength.HashJwtToken);
            builder.Property(u => u.HashRefreshToken).IsRequired().HasMaxLength(MaxLength.HashRefreshToken);
            builder.Property(u => u.Device).IsRequired().HasMaxLength(MaxLength.Device);
        }
    }
}