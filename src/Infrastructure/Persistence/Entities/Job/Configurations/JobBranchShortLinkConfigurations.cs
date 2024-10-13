namespace Persistence.Entities.Job.Configurations;

public class JobBranchShortLinkConfigurations : IEntityTypeConfiguration<JobBranchShortLink>
{
    public void Configure(EntityTypeBuilder<JobBranchShortLink> builder)
    {
        builder.ToTable("JobBranchShortLink", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.ShortKey);

        //relations
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobBranchShortLinks)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}