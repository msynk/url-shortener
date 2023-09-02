using UrlShortener.Api.Models.Identity;

namespace UrlShortener.Api.Data.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(role => role.Name).HasMaxLength(50);
    }
}

