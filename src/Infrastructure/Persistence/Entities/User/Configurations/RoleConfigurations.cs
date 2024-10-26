using Constants.Security;

namespace Persistence.Entities.User.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = new Guid("9845f909-799c-45fd-9158-58c1336ffddc").ToString(),
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                },
                new IdentityRole
                {
                    Id = new Guid("cb275765-1cac-4652-a03f-f8871dd575d1").ToString(),
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                }
            );
        }
    }
}
