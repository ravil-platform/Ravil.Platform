namespace Persistence.Entities.UploadedFile.Configurations
{
    public class UploadedFileConfigurations : IEntityTypeConfiguration<Domain.Entities.UploadedFile.UploadedFile>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.UploadedFile.UploadedFile> builder)
        {
            builder.ToTable("UploadedFiles", "UploadedFiles");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(MaxLength.Name);
            builder.Property(u => u.Extension).IsRequired();
            builder.Property(u => u.FileType).IsRequired();
        }
    }
}
