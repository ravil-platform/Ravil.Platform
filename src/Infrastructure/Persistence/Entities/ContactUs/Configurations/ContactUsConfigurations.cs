namespace Persistence.Entities.ContactUs.Configurations
{
    public class ContactUsConfigurations : IEntityTypeConfiguration<Domain.Entities.ContactUs.ContactUs>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ContactUs.ContactUs> builder)
        {
            builder.ToTable("ContactUs", "ContactUs");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(MaxLength.FullName);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(MaxLength.Email);
            builder.Property(c => c.Subject).IsRequired().HasMaxLength(MaxLength.EmailSubject);
            builder.Property(c => c.Message).IsRequired().HasMaxLength(MaxLength.EmailBody);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.UserId).IsRequired(false);
            builder.Property(c => c.UserIp).IsRequired(false);
            builder.Property(c => c.StatusAnswer).IsRequired(false);
            builder.Property(c => c.IsReadByAdmin).IsRequired(false);
            builder.Property(c => c.AnswerDate).IsRequired(false);
            builder.Property(c => c.AdminName).IsRequired(false);
            builder.Property(c => c.AdminId).IsRequired(false);
            builder.Property(c => c.Answer).IsRequired(false);
        }
    }
}
