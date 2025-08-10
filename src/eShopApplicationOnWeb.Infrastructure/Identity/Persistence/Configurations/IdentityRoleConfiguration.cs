using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Persistence.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "6dd90b01-287c-4824-94a0-c6cdf4cfbf7f",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Id = "a4d041ad-80d6-496e-9130-d04b0001b357",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
