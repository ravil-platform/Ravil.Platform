using Action = Domain.Entities.User.Action;

namespace Persistence.Entities.User.Configurations
{
    public class ActionsConfigurations : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ActionTypes).IsRequired();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.ActionScore).IsRequired();
            builder.Property(a => a.ActionPriceScore).IsRequired(false);
        }
    }
}
