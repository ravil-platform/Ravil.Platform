namespace Persistence.Entities.State.Configurations;

public class StateConfigurations : IEntityTypeConfiguration<Domain.Entities.State.State>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.State.State> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Subtitle).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(s => s.Picture).IsRequired(false).HasMaxLength(MaxLength.Picture);
        builder.Property(s => s.IsResizePicture).IsRequired();
        builder.Property(s => s.Multiplier).IsRequired(false);

        //relation
        builder
            .HasOne(s => s.StateBase)
            .WithOne(s => s.State)
            .HasForeignKey<Domain.Entities.State.State>(s => s.StateBaseId);
    }
}

