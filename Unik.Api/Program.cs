using Microsoft.EntityFrameworkCore;
using Unik.Crosscut.TransactionHandling.Implementation;
using Unik.Crosscut.TransactionHandling;
using Unik.Onboarding.Application.Commands.Booking;
using Unik.Onboarding.Application.Commands.Implementation.Booking;
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
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Commands.Implementation.User;
using Unik.Onboarding.Application.Queries.Implementation.User;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Commands.ProjectUsers;
using Unik.Onboarding.Application.Commands.Implementation.ProjectUsers;
using Unik.Onboarding.Application.Queries.Booking;
using Unik.Onboarding.Application.Queries.Implementation.Booking;

//using UnikOnBoarding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture
// Booking
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ICreateBookingCommand, CreateBookingCommand>();
builder.Services.AddScoped<IEditBookingCommand, EditBookingCommand>();
builder.Services.AddScoped<IDeleteBookingCommand, DeleteBookingCommand>();
builder.Services.AddScoped<IBookingGetAllQuery, BookingGetAllQuery>();
builder.Services.AddScoped<IBookingGetQuery, BookingGetQuery>();

// Project
builder.Services.AddScoped<IProjectDomainService, ProjectDomainService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICreateProjectCommand, CreateProjectCommand>();
builder.Services.AddScoped<IEditProjectCommand, EditProjectCommand>();
builder.Services.AddScoped<IDeleteProjectCommand, DeleteProjectCommand>();
builder.Services.AddScoped<IProjectGetAllQuery, ProjectGetAllQuery>();
builder.Services.AddScoped<IProjectGetQuery, ProjectGetQuery>();

// ProjectUsers
builder.Services.AddScoped<IAddUserToProjectCommand, AddUserToProjectCommand>();
builder.Services.AddScoped<IRemoveUserFromProjectCommand, RemoveUserFromProjectCommand>();

// UserProjects


// User
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserCommand, CreateUserCommand>();
builder.Services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
builder.Services.AddScoped<IUserGetAllQuery, UserGetAllQuery>();
builder.Services.AddScoped<IUserGetQuery, UserGetQuery>();

// Task
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ICreateTaskCommand, CreateTaskCommand>();
builder.Services.AddScoped<IEditTaskCommand, EditTaskCommand>();
builder.Services.AddScoped<IDeleteTaskCommand, DeleteTaskCommand>();
builder.Services.AddScoped<ITaskGetAllQuery, TaskGetAllQuery>();
builder.Services.AddScoped<ITaskGetQuery, TaskGetQuery>();

// Database
// Add-Migration InitialMigrationDomain -Context UnikDbContext -Project Unik.SqlServerContext.Migrations
// Update-Database -Context UnikDbContext
builder.Services.AddDbContext<UnikDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikDbConnection"),
            x => x.MigrationsAssembly("Unik.SqlServerContext.Migrations")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
{
    var db = p.GetService<UnikDbContext>();
    return new UnitOfWork(db);
});

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