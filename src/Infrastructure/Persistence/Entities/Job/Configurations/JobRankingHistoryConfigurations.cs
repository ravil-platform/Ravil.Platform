namespace Persistence.Entities.Job.Configurations;

public class JobRankingHistoryConfigurations : IEntityTypeConfiguration<JobRankingHistory>
{
    public void Configure(EntityTypeBuilder<JobRankingHistory> builder)
    {
        builder.ToTable(nameof(JobRankingHistory), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.PageUrl).HasMaxLength(MaxLength.Link);

        //relations
        builder.HasOne(w => w.Job)
            .WithMany(w => w.JobRankingHistories)
            .HasForeignKey(w => w.JobId)
            .IsRequired();
    }
}