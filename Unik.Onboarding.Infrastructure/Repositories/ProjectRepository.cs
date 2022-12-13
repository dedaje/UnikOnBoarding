using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.ProjectUsers;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly UnikDbContext _db;

    public ProjectRepository(UnikDbContext db)
    {
        _db = db;
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

    IEnumerable<ProjectUsersQueryResultDto> IProjectRepository.GetAllProjectUsers(int? projectId)
    {
        //var usersInProject = _db.ProjectEntities.AsNoTracking()
        //    .Where(x => x.Id == projectId)
        //    .Include(a => a.Users)
        //    //.FirstOrDefaultAsync();
        //    .FirstOrDefault(p => p.Id == projectId);
        
        //Få den til at springe brugere over som er i domain db, men ikke del af et project

        foreach (var project in _db.UserEntities.AsNoTracking().Include(u => u.Projects.Select(t => t.Users)))
            //if (project == null) yield break;
            yield return new ProjectUsersQueryResultDto
            {
                UserId = project.UserId,
                ProjectId = project.Projects.FirstOrDefault(p => p.Id == projectId.Value).Id,
                ProjectName = project.Projects.FirstOrDefault(p => p.Id == projectId.Value).ProjectName,
                DateCreated = project.Projects.FirstOrDefault(p => p.Id == projectId.Value).DateCreated,
                RowVersion = project.Projects.FirstOrDefault(p => p.Id == projectId.Value).RowVersion,
            };
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
        //_db.Update(model);
        //_db.SaveChanges();

        throw new NotImplementedException();
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