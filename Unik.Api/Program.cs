using Unik.Onboarding.Application.Commands.Implementation;
using Unik.Onboarding.Infrastructure.DomainServices;
using Unik.Onboarding.Infrastructure.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Queries.Implementation.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;
using Unik.Onboarding.Application.Commands.Onboarding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture
builder.Services.AddScoped<ICreateOnboardingCommand, CreateOnboardingCommand>();
builder.Services.AddScoped<IEditOnboardingCommand, EditOnboardingCommand>();
builder.Services.AddScoped<IOnboardingRepository, OnboardingRepository>();
builder.Services.AddScoped<IOnboardingGetAllQuery, OnboardingGetAllQuery>();
builder.Services.AddScoped<IOnboardingGetQuery, OnboardingGetQuery>();
builder.Services.AddScoped<IOnboardingDomainService, OnboardingDomainService>();

// Database
// Add-Migration InitialMigration -Context WebAppUserDbContext -Project Unik.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext

// Database
// Add-Migration InitialMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
// Update-Database -Context LevSundtContext

// Database
// Add-Migration InitialMigration -Context UnikDbContext -Project Unik.SqlServerContext.Migrations
// Update-Database -Context UnikDbContext
builder.Services.AddDbContext<UnikDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
            x => x.MigrationsAssembly("Unik.SqlServerContext.Migrations")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
