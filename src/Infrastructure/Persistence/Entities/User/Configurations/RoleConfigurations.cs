using Constants.Security;

namespace Persistence.Entities.User.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("9845f909-799c-45fd-9158-58c1336ffddc"),
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("cb275765-1cac-4652-a03f-f8871dd575d1"),
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                }
            );
        }
    }
}
