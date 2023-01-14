
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Medii_de_prodramare.Data;
using Microsoft.AspNetCore.Identity;
using Proiect_Medii_de_prodramare.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Games");
    options.Conventions.AllowAnonymousToPage("/Games/Index");
    options.Conventions.AllowAnonymousToPage("/Games/Details");

});
builder.Services.AddDbContext<Proiect_Medii_de_prodramareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_de_prodramareContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Medii_de_prodramareContext' not found.")));

//builder.Services.AddDefaultIdentity<Proiect_Medii_de_prodramareUser>(options => options.SignIn.RequireConfirmedAccount = true)
//.AddEntityFrameworkStores<Proiect_LibraryIdentityContext>();
builder.Services.AddDbContext<Proiect_LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_de_prodramareContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Medii_de_prodramareContext' not found.")));
builder.Services.AddDefaultIdentity<Proiect_Medii_de_prodramareUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<Proiect_LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
