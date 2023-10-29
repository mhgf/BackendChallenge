using BackendChallenge.core.Entity;
using BackendChallenge.core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Diagnostics.Activity;

namespace BackendChallenge.infra.Database.Configuration
{
    internal class UserConfiguration : BaseEntityConfiguration<User>
    {
        private UserConfiguration()
        {
        }
        public static void Config(EntityTypeBuilder<User> builder) => new UserConfiguration().Configure(builder);

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode();

            builder.Property(x => x.Balance).HasDefaultValue<decimal>(decimal.Zero);

            builder.Property(b => b.Password).IsRequired().HasMaxLength(100);

            builder.Property(b => b.Type).HasConversion(v => v.ToString(), v => Enumeration.Parce<UserType>(v)).HasDefaultValue(UserType.COMMON).IsRequired();

            builder.Property(b => b.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(b => b.UpdatedAt);

            builder.Metadata?.FindNavigation(nameof(User.Sent))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata?.FindNavigation(nameof(User.Received))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
