namespace Persistence.Entities.Service.Configurations;

public class ServiceConfigurations : IEntityTypeConfiguration<Domain.Entities.Service.Service>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Service.Service> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.ServiceTitle).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(s => s.ServiceSummary).IsRequired().HasMaxLength(MaxLength.Summary);
        builder.Property(s => s.ParentId).IsRequired(false);
        builder.Property(s => s.ServicePicture).IsRequired(false);
        builder.Property(s => s.Sort).IsRequired(false);

        //relations
        builder
            .HasMany(s => s.JobServices)
            .WithOne(j => j.Service)
            .HasForeignKey(j => j.ServiceId)
            .IsRequired();

        builder
            .HasMany(s => s.CategoryServices)
            .WithOne(j => j.Service)
            .HasForeignKey(j => j.ServiceId)
            .IsRequired();
    }
}

