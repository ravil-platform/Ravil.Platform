namespace Persistence.Entities.Job.Configurations;

public class JobKeywordConfigurations : IEntityTypeConfiguration<JobKeyword>
{
    public void Configure(EntityTypeBuilder<JobKeyword> builder)
    {
        builder.ToTable(nameof(JobKeyword), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        //builder.Property(j => j.CostPerClick).IsRequired();
        builder.Property(j => j.KeywordId).IsRequired();
        builder.Property(j => j.JobBranchId).IsRequired();

        //relation
        builder.HasOne(k => k.Keyword)
            .WithMany(c => c.JobKeywords)
            .HasForeignKey(c => c.KeywordId)
            .IsRequired();

        builder.HasOne(k => k.JobBranch)
            .WithMany(c => c.JobKeywords)
            .HasForeignKey(c => c.JobBranchId)
            .IsRequired();
    }
}