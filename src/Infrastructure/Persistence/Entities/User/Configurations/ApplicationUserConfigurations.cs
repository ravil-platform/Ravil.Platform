using Common.Utilities.Extensions;

namespace Persistence.Entities.User.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser", DatabaseSchemas.Users);

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Firstname).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(u => u.Lastname).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(u => u.BirthDate).IsRequired(false);
            builder.Property(u => u.RegisterDate).IsRequired();
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


            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = new Guid("05446344-f9cc-4566-bd2c-36791b4e28ed").ToString(),
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    Firstname = "Admin",
                    Lastname = "System",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Avicen_AdminP@ssword1"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = new Guid("2ec9f480-7288-4d0f-a1cd-53cc89968b45").ToString(),
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    Firstname = "System",
                    Lastname = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Avicen_UserP@ssword1"),
                    EmailConfirmed = true,
                });
            //relations
            //builder
            //    .HasOne(u => u.Wallet)
            //    .WithOne(w => w.User)
            //    .HasForeignKey<Wallet>(w => w.UserId);

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
                .HasMany(u => u.Comments)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder
                .HasMany(u => u.JobBranches)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            //builder
            //    .HasMany(u => u.Transactions)
            //    .WithOne(o => o.ApplicationUser)
            //    .HasForeignKey(o => o.UserId)
            //    .IsRequired();

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
                .HasMany(u => u.UserBlogLikes)
                .WithOne(o => o.ApplicationUser)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            //identity relations
            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).IsUnicode(false).HasMaxLength(512);
            builder.Property(u => u.NormalizedUserName).IsUnicode(false).HasMaxLength(512);
            builder.Property(u => u.Email).IsUnicode(false).HasMaxLength(512);
            builder.Property(u => u.NormalizedEmail).IsUnicode(false).HasMaxLength(512);

            // Each User can have many UserClaims
            builder
                .HasMany<IdentityUserClaim<string>>()
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();
            // Each User can have many UserLogins
            builder
                .HasMany<IdentityUserLogin<string>>()
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder
                .HasMany<IdentityUserToken<string>>()
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder
                .HasMany<IdentityUserRole<string>>()
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
