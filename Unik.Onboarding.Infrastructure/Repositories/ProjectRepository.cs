using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Project;
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
        var project = _db.ProjectEntities.Include(x => x.Users).SingleOrDefault(x => x.ProjectId == projectId.ProjectId);

        project.Users.Add(initialUser);
        _db.SaveChanges();
    }

    IEnumerable<ProjectUsersQueryResultDto> IProjectRepository.GetAllUserProjects(int? projectId, int? usersId)
    {
        var usersInProject = _db.ProjectEntities.AsNoTracking().Where(p => p.ProjectId == projectId).SelectMany(c => c.Users).ToList();
        
        //foreach (var usersInProject in _db.ProjectEntities.AsNoTracking().Where(p => p.ProjectId == projectId).SelectMany(c => c.Users).ToList())
        //    yield return new ProjectUsersQueryResultDto
        //    {
                
        //    };

        //foreach (var entity in _db.UserEntities.AsNoTracking().Include(a => a.Projects).Where(a => a.Id == usersId)/*.Distinct()*/.ToList())
        //    yield return new ProjectUsersQueryResultDto
        //    {
        //        ProjectQuery = new ProjectQueryResultDto
        //        { ProjectId = entity.}
        //    };

        //foreach (var projectEntity in _db.ProjectEntities.AsNoTracking().Where(a => a.ProjectId == projectId).ToList())
        //{
        //    new ProjectQueryResultDto
        //    {
        //        ProjectId = projectEntity.ProjectId,
        //        ProjectName = projectEntity.ProjectName,
        //        DateCreated = projectEntity.DateCreated,
        //        RowVersion = projectEntity.RowVersion,
        //    };


        //}

        throw new NotImplementedException();
    }

    IEnumerable<ProjectQueryResultDto> IProjectRepository.GetAllProjects()
    {
        foreach (var entity in _db.ProjectEntities.AsNoTracking().ToList())
            yield return new ProjectQueryResultDto
            {
                ProjectId = entity.ProjectId,
                ProjectName = entity.ProjectName,
                DateCreated = entity.DateCreated,
                RowVersion = entity.RowVersion
            };
    }

    ProjectQueryResultDto IProjectRepository.GetProject(int projectId)
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Dette projekt findes ikke");

        return new ProjectQueryResultDto
        {
            ProjectId = dbEntity.ProjectId,
            ProjectName = dbEntity.ProjectName,
            DateCreated = dbEntity.DateCreated,
            RowVersion = dbEntity.RowVersion
        };
    }

    ProjectEntity IProjectRepository.LoadProject(int projectId) 
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId);
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
        var project = _db.ProjectEntities.Include(x => x.Users).SingleOrDefault(x => x.ProjectId == projectId.ProjectId);
        var deleteUser = project.Users.SingleOrDefault(x => x.Id == userId.Id);

        project.Users.Remove(deleteUser);
        _db.SaveChanges();

        //throw new NotImplementedException();
    }
}