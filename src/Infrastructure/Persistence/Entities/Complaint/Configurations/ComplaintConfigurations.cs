namespace Persistence.Entities.Complaint.Configurations
{
    public class ComplaintConfigurations : IEntityTypeConfiguration<Domain.Entities.Complaint.Complaint>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Complaint.Complaint> builder)
        {
            builder.ToTable("Complaints", "Complaints");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(MaxLength.FullName);
            builder.Property(c => c.Email).IsRequired(false).HasMaxLength(MaxLength.Email);
            builder.Property(c => c.Subject).IsRequired().HasMaxLength(MaxLength.EmailSubject);
            builder.Property(c => c.ComplaintText).IsRequired().HasMaxLength(MaxLength.Comment);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.IsReadByAdmin).IsRequired(false);
            builder.Property(c => c.CreateDate).IsRequired();
        }
    }
}
