namespace Persistence.Entities.Job.Configurations;

public class JobRankingConfigurations : IEntityTypeConfiguration<JobRanking>
{
    public void Configure(EntityTypeBuilder<JobRanking> builder)
    {
        builder.ToTable("JobRanking", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.PageUrl).HasMaxLength(MaxLength.Slug);

        //relations
        builder.HasOne(w => w.Job)
            .WithOne(w => w.JobRanking)
            .HasForeignKey<JobRanking>(w => w.JobId);
    }
}