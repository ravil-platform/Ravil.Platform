namespace Persistence.Entities.DayOfWeek.Configurations
{
    public class DayOfWeekConfigurations : IEntityTypeConfiguration<Domain.Entities.DayOfWeek.DayOfWeek>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DayOfWeek.DayOfWeek> builder)
        {
            builder.ToTable("DayOfWeek", DatabaseSchemas.Schema);

            builder.HasKey(d => d.Id);
            builder.Property(d => d.AlternateName).IsRequired(false);
            builder.Property(d => d.PersianName).IsRequired().HasMaxLength(MaxLength.Name);
            builder.Property(d => d.Sort).IsRequired();
            builder.Property(d => d.IsSelectedPersianName).IsRequired();

            //relations
            builder
                .HasMany(d => d.JobTimeWorks)
                .WithOne(d => d.DayOfWeek)
                .HasForeignKey(j => j.DayOfWeekId)
                .IsRequired();
        }
    }
}
