using Unik.Onboarding.Application.Commands;
using Unik.Onboarding.Application.Commands.Implementation;
using Unik.Onboarding.Application.Queries;
using Unik.Onboarding.Application.Queries.Implementation;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model.DomainServices;
using Unik.Onboarding.Infrastructure.DomainServices;
using Unik.Onboarding.Infrastructure.Repositories;
using Unik.SqlServerContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture
//TODO: tilføj services

// Database
// Add-Migration InitialMigration -Context WebAppUserDbContext -Project Unik.SqlServerContext.Migrations
// Update-Database -Context WebAppUserDbContext
builder.Services.AddDbContext<UnikContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
            x => x.MigrationsAssembly("Unik.WebApp.UserContext.Migrations")));

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
