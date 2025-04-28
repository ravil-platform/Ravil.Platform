namespace Persistence.Entities.MessageBox.Configurations
{
    public class MessageBoxConfigurations : IEntityTypeConfiguration<Domain.Entities.MessageBox.MessageBox>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.MessageBox.MessageBox> builder)
        {
            builder.ToTable("MessageBox", DatabaseSchemas.Shared);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Description).IsRequired();

            //relations
            builder
                .HasOne(m => m.Job)
                .WithMany(j => j.MessageBoxes)
                .HasForeignKey(m => m.JobId)
                .IsRequired();
        }
    }
}
