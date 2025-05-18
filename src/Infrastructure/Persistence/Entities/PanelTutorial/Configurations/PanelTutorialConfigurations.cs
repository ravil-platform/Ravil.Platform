namespace Persistence.Entities.PanelTutorial.Configurations
{
    public class PanelTutorialConfigurations : IEntityTypeConfiguration<Domain.Entities.PanelTutorial.PanelTutorial>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.PanelTutorial.PanelTutorial> builder)
        {
            builder.ToTable(nameof(PanelTutorial), DatabaseSchemas.Shared);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.CoverName).IsRequired();
            builder.Property(b => b.VideoName).IsRequired();
            builder.Property(c => c.Time);
        }
    }
}
