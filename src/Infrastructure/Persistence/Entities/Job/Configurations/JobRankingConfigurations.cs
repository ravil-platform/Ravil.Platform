namespace Persistence.Entities.Job.Configurations;

public class JobRankingConfigurations : IEntityTypeConfiguration<JobRanking>
{
    public void Configure(EntityTypeBuilder<JobRanking> builder)
    {
        builder.ToTable("JobRankings", "Jobs");

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Sort).IsRequired(false);
        builder.Property(j => j.ExpireSortDay).IsRequired(false);
        builder.Property(j => j.RegisterDate).IsRequired(false);
        builder.Property(j => j.LastUpdateDate).IsRequired(false);
        builder.Property(j => j.RegisterHistoryDay).IsRequired(false);
        builder.Property(j => j.JobReviewCount).IsRequired(false);
        builder.Property(j => j.JobSharedCount).IsRequired(false);
        builder.Property(j => j.JobCommentCount).IsRequired(false);
        builder.Property(j => j.ViewCount).IsRequired(false);
        builder.Property(j => j.TotalScore).IsRequired(false);
    }
}