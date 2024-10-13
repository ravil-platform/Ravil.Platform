namespace Persistence.Entities.Attr.Configurations
{
    public class AttrCategoryConfigurations : IEntityTypeConfiguration<AttrCategory>
    {
        public void Configure(EntityTypeBuilder<AttrCategory> builder)
        {
            builder.ToTable("AttrCategory", DatabaseSchemas.Attrs);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.Sort).IsRequired();
            builder.Property(a => a.IconPicture).IsRequired(false);
        }
    }
}
