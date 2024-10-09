namespace Persistence.Entities.Job.Configurations;

public class JobBranchAttrConfigurations : IEntityTypeConfiguration<JobBranchAttr>
{
    public void Configure(EntityTypeBuilder<JobBranchAttr> builder)
    {
        builder.HasKey(j => j.Id);

        //relations
        builder
            .HasOne(j => j.Attr)
            .WithMany(a => a.AttrJobBranches)
            .HasForeignKey(j => j.AttrId)
            .IsRequired();

        builder
            .HasOne(j => j.AttrValue)
            .WithMany(a => a.JobBranchAttrs)
            .HasForeignKey(j => j.ValueId)
            .IsRequired();
    }
}