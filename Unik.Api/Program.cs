using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Commands.Implementation.Onboarding;
using Unik.Onboarding.Application.Commands.Implementation.OnboardingUsers;
using Unik.Onboarding.Application.Commands.Implementation.Role;
using Unik.Onboarding.Application.Commands.Implementation.Skill;
using Unik.Onboarding.Application.Commands.Implementation.User;
using Unik.Onboarding.Application.Commands.Implementation.UserSkills;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Commands.OnboardingUsers;
using Unik.Onboarding.Application.Commands.Role;
using Unik.Onboarding.Application.Commands.Skill;
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Commands.UserSkills;
using Unik.Onboarding.Application.Queries.Implementation.Onboarding;
using Unik.Onboarding.Application.Queries.Implementation.OnboardingUsers;
using Unik.Onboarding.Application.Queries.Implementation.Role;
using Unik.Onboarding.Application.Queries.Implementation.Skill;
using Unik.Onboarding.Application.Queries.Implementation.User;
using Unik.Onboarding.Application.Queries.Implementation.UserSkills;
using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Queries.UserSkills;
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
builder.Services.AddScoped<IProjectGetAllQuery, OnboardingGetAllQuery>();
builder.Services.AddScoped<IProjectGetQuery, OnboardingGetQuery>();
//builder.Services.AddScoped<IOnboardingDomainService, OnboardingDomainService>();

builder.Services.AddScoped<IOnboardingUsersRepository, OnboardingUsersRepository>();
builder.Services.AddScoped<ICreateOnboardingUsersCommand, CreateOnboardingUsersCommand>();
builder.Services.AddScoped<IEditOnboardingUsersCommand, EditOnboardingUsersCommand>();
builder.Services.AddScoped<IOnboardingUsersGetAllQuery, OnboardingUsersGetAllQuery>();
builder.Services.AddScoped<IOnboardingUsersGetQuery, OnboardingUsersGetQuery>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICreateRoleCommand, CreateRoleCommand>();
builder.Services.AddScoped<IEditRoleCommand, EditRoleCommand>();
builder.Services.AddScoped<IRoleGetAllQuery, RoleGetAllQuery>();
builder.Services.AddScoped<IRoleGetQuery, RoleGetQuery>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ICreateSkillCommand, CreateSkillCommand>();
builder.Services.AddScoped<IEditSkillCommand, EditSkillCommand>();
builder.Services.AddScoped<ISkillGetAllQuery, SkillGetAllQuery>();
builder.Services.AddScoped<ISkillGetQuery, SkillGetQuery>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserCommand, CreateUserCommand>();
builder.Services.AddScoped<IEditUserCommand, EditUserCommand>();
builder.Services.AddScoped<IUserGetAllQuery, UserGetAllQuery>();
builder.Services.AddScoped<IUserGetQuery, UserGetQuery>();

builder.Services.AddScoped<IUserSkillsRepository, UserSkillsRepository>();
builder.Services.AddScoped<ICreateUserSkillsCommand, CreateUserSkillsCommand>();
builder.Services.AddScoped<IEditUserSkillsCommand, EditUserSkillsCommand>();
builder.Services.AddScoped<IUserSkillsGetAllQuery, UserSkillsGetAllQuery>();
builder.Services.AddScoped<IUserSkillsGetQuery, UserSkillsGetQuery>();

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