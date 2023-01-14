using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Areas.Identity.Data;

namespace Proiect_Medii_de_prodramare.Data;

public class Proiect_LibraryIdentityContext : IdentityDbContext<Proiect_Medii_de_prodramareUser>
{
    public Proiect_LibraryIdentityContext(DbContextOptions<Proiect_LibraryIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
