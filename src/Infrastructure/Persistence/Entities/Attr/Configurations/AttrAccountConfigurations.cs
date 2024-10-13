namespace Persistence.Entities.Attr.Configurations
{
    public class AttrAccountConfigurations : IEntityTypeConfiguration<AttrAccount>
    {
        public void Configure(EntityTypeBuilder<AttrAccount> builder)
        {
            builder.ToTable("AttrAccount", DatabaseSchemas.Attrs);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.AttrType).IsRequired();
            builder.Property(a => a.Sort).IsRequired();
            builder.Property(a => a.IconPicture).IsRequired(false);
            builder.Property(a => a.IconHtmlCode).IsRequired(false);

            //relations
            builder
                .HasMany(a => a.AttrAccountValues)
                .WithOne(a => a.AttrAccount)
                .HasForeignKey(a => a.AttrAccountId)
                .IsRequired();

            builder
                .HasOne(a => a.AttrCategory)
                .WithMany(a => a.AttributeAccounts)
                .HasForeignKey(a => a.AttrCategoryId)
                .IsRequired();

        }
    }
}
