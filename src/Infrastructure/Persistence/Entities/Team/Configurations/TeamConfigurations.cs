namespace Persistence.Entities.Team.Configurations
{
    public class TeamConfigurations : IEntityTypeConfiguration<Domain.Entities.Team.Team>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Team.Team> builder)
        {
            builder.ToTable("Team", DatabaseSchemas.Teams);

            builder.HasKey(t => t.Id);
            builder.Property(t => t.FullName).IsRequired().HasMaxLength(MaxLength.FullName);
            builder.Property(t => t.Degree).IsRequired().HasMaxLength(MaxLength.Degree);
            builder.Property(t => t.Avatar).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(t => t.HoverPic).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(t => t.Description).IsRequired(false).HasMaxLength(MaxLength.Description);
            builder.Property(t => t.Instagram).IsRequired(false);
            builder.Property(t => t.Telegram).IsRequired(false);
            builder.Property(t => t.Twitter).IsRequired(false);
            builder.Property(t => t.WhatsApp).IsRequired(false);
            builder.Property(t => t.Sort).IsRequired();
        }
    }
}
