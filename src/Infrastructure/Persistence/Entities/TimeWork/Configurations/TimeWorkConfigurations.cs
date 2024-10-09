namespace Persistence.Entities.TimeWork.Configurations
{
    public class TimeWorkConfigurations : IEntityTypeConfiguration<Domain.Entities.TimeWork.TimeWork>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TimeWork.TimeWork> builder)
        {
            builder.ToTable("TimeWorks", "TimeWorks");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.StartTime).IsRequired();
            builder.Property(t => t.EndTime).IsRequired();

            //relations
            builder
                .HasMany(t => t.TimeWorkDayOfWeeks)
                .WithOne(t => t.TimeWork)
                .HasForeignKey(t => t.TimeWorkId)
                .IsRequired();
        }
    }
}
