using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Commands.Implementation.Project;
using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Queries.Implementation.Project;
using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Infrastructure.Repositories;
using Unik.SqlServerContext;

//using UnikOnBoarding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICreateProjectCommand, CreateProjectCommand>();
builder.Services.AddScoped<IEditProjectCommand, EditProjectCommand>();
builder.Services.AddScoped<IProjectGetAllQuery, ProjectGetAllQuery>();
builder.Services.AddScoped<IProjectGetQuery, ProjectGetQuery>();
//builder.Services.AddScoped<IOnboardingDomainService, OnboardingDomainService>();

// Database
// Add-Migration InitialMigrationDomain -Context UnikDbContext -Project Unik.SqlServerContext.Migrations
// Update-Database -Context UnikDbContext
builder.Services.AddDbContext<UnikDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
            x => x.MigrationsAssembly("Unik.SqlServerContext.Migrations")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();