namespace Persistence.Entities.Attr.Configurations
{
    public class AttrConfigurations : IEntityTypeConfiguration<Domain.Entities.Attr.Attr>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attr.Attr> builder)
        {
            builder.ToTable("Attr", DatabaseSchemas.Attrs);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.AttrType).IsRequired();
            builder.Property(a => a.Filter).IsRequired();
            builder.Property(a => a.ShowInPage).IsRequired();
            builder.Property(a => a.Sort).IsRequired();
            builder.Property(a => a.IconPicture).IsRequired(false);

            //relations
            builder
                .HasOne(a => a.AttrCategory)
                .WithMany(a => a.Attributes)
                .HasForeignKey(a => a.AttrCategoryId)
                .IsRequired(false);

            builder
                .HasMany(a => a.AttrValues)
                .WithOne(a => a.Attr)
                .HasForeignKey(a => a.AttrId);
        }
    }
}
