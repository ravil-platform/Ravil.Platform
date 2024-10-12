namespace Persistence.Entities.User.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users", "Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Firstname).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(u => u.Lastname).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(u => u.BirthDate).IsRequired(false);
            builder.Property(u => u.RegisterDate).IsRequired(false);
            builder.Property(u => u.ConfirmationDate).IsRequired(false);
            builder.Property(u => u.LockoutReason).IsRequired(false).HasMaxLength(MaxLength.Description);
            builder.Property(u => u.NationalCode).IsRequired(false).HasMaxLength(MaxLength.NationalCode);
            builder.Property(u => u.Phone).IsRequired(false).HasMaxLength(MaxLength.Phone);
            builder.Property(u => u.Address).IsRequired(false).HasMaxLength(MaxLength.Address);
            builder.Property(u => u.Avatar).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.OneTimeUseCode).IsRequired(false).HasMaxLength(MaxLength.Code);
            builder.Property(u => u.OneTimeUseCodeEnd);
            builder.Property(u => u.UserIsBlocked);
            builder.Property(u => u.BlockedDate);
            builder.Property(u => u.ExpireTimeSpanBlock);
            builder.Property(u => u.IsDeleted);
            builder.Property(u => u.UpdateDate);
            builder.Property(u => u.LastUpdateDateReason);
            builder.Property(u => u.LastDeleteBicycleDate);
            builder.Property(u => u.UserNameType);

            //relations
            builder
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId);

            builder
                .HasOne(u => u.StateBase)
                .WithMany(s => s.ApplicationUsers)
                .HasForeignKey(u => u.StateBaseId)
                .IsRequired(false);

            builder
                .HasOne(u => u.CityBase)
                .WithMany(s => s.ApplicationUsers)
                .HasForeignKey(u => u.CityBaseId)
                .IsRequired(false);

            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.Comments)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.JobBranches)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.Transactions)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.UserAddresses)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.UserBookMarks)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.UserBlogActions)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.UserBlogLikes)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired(); 
            
            builder
                .HasMany(u => u.UserJobAction)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.UserLikedGalleries)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();
        }
    }
}
