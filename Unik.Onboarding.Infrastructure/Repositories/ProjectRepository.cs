using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.ProjectUsers;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly UnikDbContext _db;
    private readonly IUserDomainService _userDomainService;

    public ProjectRepository(UnikDbContext db, IUserDomainService userDomainService)
    {
        _db = db;
        _userDomainService = userDomainService;
    }

    void IProjectRepository.CreateWithInitialUser(UsersEntity initialUserId, ProjectEntity projectId)
    {
        _db.Add(projectId);
        _db.SaveChanges();

        var initialUser = _db.UserEntities.SingleOrDefault(x => x.Id == initialUserId.Id);
        var project = _db.ProjectEntities.Include(x => x.Users).SingleOrDefault(x => x.Id == projectId.Id);

        project.Users.Add(initialUser);
        _db.SaveChanges();
    }

    void IProjectRepository.AddUserToProject(UsersEntity user, ProjectEntity project)
    {
        var newUser = _db.UserEntities.SingleOrDefault(x => x.Id == user.Id);
        var existingProject = _db.ProjectEntities.Include(x => x.Users).SingleOrDefault(x => x.Id == project.Id);

        existingProject.Users.Add(newUser);
        _db.SaveChanges();
    }

    private ProjectUsersQueryResultDto ProjectUsersDto { get; set; } = new();

    IEnumerable<ProjectUsersQueryResultDto> IProjectRepository.GetAllProjectUsers(int? projectId)
    {
        //var projectUsers = _db.UserEntities.AsNoTracking().Include(u => u.Projects.Where(p => p.Id == projectId));

        foreach (var users in _db.UserEntities.AsNoTracking().Include(u => u.Projects.Where(p => p.Id == projectId)))
        {
            ProjectUsersDto.UserId = users.UserId;

            foreach (var project in users.Projects)
            {
                ProjectUsersDto.ProjectId = project.Id;
                ProjectUsersDto.ProjectName = project.ProjectName;
                ProjectUsersDto.DateCreated = project.DateCreated;
                ProjectUsersDto.RowVersion = project.RowVersion;

                yield return new ProjectUsersQueryResultDto
                {
                    ProjectId = ProjectUsersDto.ProjectId,
                    ProjectName = ProjectUsersDto.ProjectName,
                    DateCreated = ProjectUsersDto.DateCreated,
                    RowVersion = ProjectUsersDto.RowVersion,
                    UserId = ProjectUsersDto.UserId
                };
            }
        }
    }

    IEnumerable<ProjectQueryResultDto> IProjectRepository.GetAllProjects()
    {
        foreach (var entity in _db.ProjectEntities.AsNoTracking().ToList())
            yield return new ProjectQueryResultDto
            {
                ProjectId = entity.Id,
                ProjectName = entity.ProjectName,
                DateCreated = entity.DateCreated,
                RowVersion = entity.RowVersion
            };
    }

    ProjectQueryResultDto IProjectRepository.GetProject(int projectId)
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.Id == projectId);
        if (dbEntity == null) throw new Exception("Dette projekt findes ikke");

        return new ProjectQueryResultDto
        {
            ProjectId = dbEntity.Id,
            ProjectName = dbEntity.ProjectName,
            DateCreated = dbEntity.DateCreated,
            RowVersion = dbEntity.RowVersion
        };
    }

    ProjectEntity IProjectRepository.LoadProject(int projectId) 
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.Id == projectId);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen");

        return dbEntity;
    }

    void IProjectRepository.UpdateProject(ProjectEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }

    void IProjectRepository.DeleteProject(ProjectEntity model)
    {
        _db.Remove(model);
        _db.SaveChanges();
    }

    void IProjectRepository.RemoveUserFromProject(UsersEntity userId, ProjectEntity projectId)
    {
        //var deleteUser = _db.UserEntities.SingleOrDefault(x => x.Id == userId.Id);
        var project = _db.ProjectEntities.Include(x => x.Users).SingleOrDefault(x => x.Id == projectId.Id);
        var deleteUser = project.Users.SingleOrDefault(x => x.Id == userId.Id);

        project.Users.Remove(deleteUser);
        _db.SaveChanges();

        //throw new NotImplementedException();
    }
}