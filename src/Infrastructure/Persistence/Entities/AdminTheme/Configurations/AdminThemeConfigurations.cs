namespace Persistence.Entities.AdminTheme.Configurations
{
    public class AdminThemeConfigurations : IEntityTypeConfiguration<Domain.Entities.AdminTheme.AdminTheme>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.AdminTheme.AdminTheme> builder)
        {
            builder.ToTable("AdminTheme", DatabaseSchemas.AdminThemes);

            builder.HasKey(a => a.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Theme).IsRequired();
        }
    }
}
