using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Unik.SqlServerContext;
using Unik.WebApp.UserContext;
using UnikOnBoarding.Areas.Identity.Data;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add-Migration InitialMigration -Context WebAppUserDbContext -Project Unik.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection") ?? throw new InvalidOperationException("Connection string 'WebAppUserDbConnection' not found.");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString,
        x=> x.MigrationsAssembly("Unik.WebApp.UserContext.Migrations")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ApplicationClaimTypes.policy.AdminPolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Admin.ToString()));
    options.AddPolicy(ApplicationClaimTypes.policy.SælgerPolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Sælger.ToString()));
    options.AddPolicy(ApplicationClaimTypes.policy.TeknikkerPolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Teknikker.ToString()));
    options.AddPolicy(ApplicationClaimTypes.policy.ConverterPolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Converter.ToString()));
    options.AddPolicy(ApplicationClaimTypes.policy.KonsulentPolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Konsulent.ToString()));
    options.AddPolicy(ApplicationClaimTypes.policy.KundePolicy.ToString(), policyBuilder => policyBuilder.RequireClaim(ApplicationClaimTypes.claims.Kunde.ToString()));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Project");
    //options.Conventions.AuthorizeFolder("/Project", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Index/", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Index/", ApplicationClaimTypes.policy.SælgerPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Create/", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Create/", ApplicationClaimTypes.policy.SælgerPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Edit/", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Edit/", ApplicationClaimTypes.policy.SælgerPolicy.ToString());
    options.Conventions.AuthorizePage("/Project/Delete/", ApplicationClaimTypes.policy.AdminPolicy.ToString());

    options.Conventions.AuthorizeFolder("/ProjectUsers");
    options.Conventions.AuthorizePage("/ProjectUsers/AddUser/", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/ProjectUsers/AddUser/", ApplicationClaimTypes.policy.SælgerPolicy.ToString());
    options.Conventions.AuthorizePage("/ProjectUsers/RemoveUser/", ApplicationClaimTypes.policy.AdminPolicy.ToString());
    options.Conventions.AuthorizePage("/ProjectUsers/RemoveUser/", ApplicationClaimTypes.policy.SælgerPolicy.ToString());

    options.Conventions.AuthorizeFolder("/Tasks");
    options.Conventions.AuthorizeFolder("/User", ApplicationClaimTypes.policy.AdminPolicy.ToString());

    options.Conventions.AuthorizeFolder("/Areas/Identity/Pages/Admin", ApplicationClaimTypes.policy.AdminPolicy.ToString());
});

// IHttpClientFactory
builder.Services.AddHttpClient<IUnikService, UnikService>(
    client => client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]));

// Database
// Add-Migration InitialMigration -Context UnikDbContext -Project Unik.SqlServerContext.Migrations
// Update-Database -Context UnikDbContext
//builder.Services.AddDbContext<UnikDbContext>(
//    options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
//            x => x.MigrationsAssembly("Unik.SqlServerContext.Migrations")));

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
