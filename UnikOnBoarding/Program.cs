using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Unik.SqlServerContext;
using Unik.WebApp.UserContext;
var builder = WebApplication.CreateBuilder(args);

// Add-Migration InitialMigration -Context WebAppUserDbContext -Project Unik.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection") ?? throw new InvalidOperationException("Connection string 'WebAppUserDbConnection' not found.");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString,
        x=> x.MigrationsAssembly("Unik.WebApp.UserContext.Migrations")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<WebAppUserDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

// Clean Architecture


//// Database
//// Add-Migration InitialMigration -Context WebAppUserDbContext -Project Unik.SqlServerContext.Migrations
//// Update-Database -Context WebAppUserDbContext
//builder.Services.AddDbContext<UnikContext>(
//    options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
//            x=> x.MigrationsAssembly("Unik.WebApp.UserContext.Migrations")));

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