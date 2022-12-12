using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Unik.SqlServerContext;
using Unik.WebApp.UserContext;
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
    options.AddPolicy("AdminPolicy", policyBuilder => policyBuilder.RequireClaim("Admin"));
    options.AddPolicy("SælgerPolicy", policyBuilder => policyBuilder.RequireClaim("Sælger"));
    options.AddPolicy("TeknikkerPolicy", policyBuilder => policyBuilder.RequireClaim("Teknikker"));
    options.AddPolicy("ConverterPolicy", policyBuilder => policyBuilder.RequireClaim("Converter"));
    options.AddPolicy("KonsulentPolicy", policyBuilder => policyBuilder.RequireClaim("Konsulent"));
    options.AddPolicy("KundePolicy", policyBuilder => policyBuilder.RequireClaim("Kunde"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Project");
    //options.Conventions.AuthorizeFolder("/Project", "AdminPolicy");
    options.Conventions.AuthorizePage("/Project/Index/", "AdminPolicy");
    options.Conventions.AuthorizePage("/Project/Index/", "SælgerPolicy");
    options.Conventions.AuthorizePage("/Project/Create/", "AdminPolicy");
    options.Conventions.AuthorizePage("/Project/Create/", "SælgerPolicy");
    options.Conventions.AuthorizePage("/Project/Edit/", "AdminPolicy");
    options.Conventions.AuthorizePage("/Project/Edit/", "SælgerPolicy");
    options.Conventions.AuthorizePage("/Project/Delete/", "AdminPolicy");

    options.Conventions.AuthorizeFolder("/ProjectUsers");
    options.Conventions.AuthorizeFolder("/Tasks");
    options.Conventions.AuthorizeFolder("/User");

    options.Conventions.AuthorizeFolder("/Areas/Identity/Pages/Admin", "AdminPolicy");
});

// IHttpClientFactory
//ops find ud af hvordan man fixer at api ikke peger p� WebApp alts� semesterproject for os og istedet peger p� det rigtige
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
