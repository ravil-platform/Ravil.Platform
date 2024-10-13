namespace Persistence.Entities.Attr.Configurations
{
    public class AttrAccountValueConfigurations : IEntityTypeConfiguration<AttrAccountValue>
    {
        public void Configure(EntityTypeBuilder<AttrAccountValue> builder)
        {
            builder.ToTable("AttrAccountValue", DatabaseSchemas.Attrs);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Value).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.Sort).IsRequired();
        }
    }
}
