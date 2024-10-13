namespace Persistence.Entities.Attr.Configurations
{
    public class AttrValueConfigurations : IEntityTypeConfiguration<AttrValue>
    {
        public void Configure(EntityTypeBuilder<AttrValue> builder)
        {
            builder.ToTable("AttrValue", DatabaseSchemas.Attrs);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Value).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.Sort).IsRequired();
        }
    }
}
