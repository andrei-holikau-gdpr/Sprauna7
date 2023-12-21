using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sprauna7Publish.Areas.Identity.Data;
using System.Reflection.Emit;

namespace Sprauna7Publish.Data;

public class AccountContext : IdentityDbContext<ApplicationUser>
{
    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.firstName)
        .HasMaxLength(250);

        modelBuilder.Entity<ApplicationUser>()
            .Property(e => e.lastName)
            .HasMaxLength(250);
    }
}
