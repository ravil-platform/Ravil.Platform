namespace Persistence.Entities.State.Configurations;

public class StateBaseConfigurations : IEntityTypeConfiguration<StateBase>
{
    public void Configure(EntityTypeBuilder<StateBase> builder)
    {
        builder.ToTable("StateBase", DatabaseSchemas.Sates);

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(MaxLength.Name);
        builder.Property(s => s.Multiplier).IsRequired();

        //relation
        builder
            .HasMany(s => s.MainSliders)
            .WithOne(m => m.State)
            .HasForeignKey(m => m.StateId)
            .IsRequired();
    }
}