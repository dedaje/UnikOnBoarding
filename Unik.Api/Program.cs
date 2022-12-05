using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Commands.Implementation.Project;
using Unik.Onboarding.Application.Commands.Implementation.Task;
using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Queries.Implementation.Project;
using Unik.Onboarding.Application.Queries.Implementation.Task;
using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Infrastructure.DomainServices;
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
// Project
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICreateProjectCommand, CreateProjectCommand>();
builder.Services.AddScoped<IEditProjectCommand, EditProjectCommand>();
builder.Services.AddScoped<IDeleteProjectCommand, DeleteProjectCommand>();
builder.Services.AddScoped<IProjectGetAllQuery, ProjectGetAllQuery>();
builder.Services.AddScoped<IProjectGetQuery, ProjectGetQuery>();

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddUserCommand, AddUserCommand>();
builder.Services.AddScoped<IRemoveUserCommand, RemoveUserCommand>();

// Task
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ICreateTaskCommand, CreateTaskCommand>();
builder.Services.AddScoped<IEditTaskCommand, EditTaskCommand>();
builder.Services.AddScoped<IDeleteTaskCommand, DeleteTaskCommand>();
builder.Services.AddScoped<ITaskGetAllQuery, TaskGetAllQuery>();
builder.Services.AddScoped<ITaskGetQuery, TaskGetQuery>();

builder.Services.AddScoped<IProjectDomainService, ProjectDomainService>();

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