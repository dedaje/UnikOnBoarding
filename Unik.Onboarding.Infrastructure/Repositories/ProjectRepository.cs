using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Project;
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

    void IProjectRepository.Add(ProjectEntity project)
    {
        _db.Add(project);
        _db.SaveChanges();
    }

    IEnumerable<ProjectQueryResultDto> IProjectRepository.GetAllUserProjects(string userId)
    {
        foreach (var entity in _db.ProjectEntities.AsNoTracking().Where(a => a.UserId == userId)/*.Distinct()*/.ToList())
            yield return new ProjectQueryResultDto
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                ProjectName = entity.ProjectName,
                DateAdded = entity.DateAdded,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    IEnumerable<ProjectQueryResultDto> IProjectRepository.GetAllEditProjects(int? projectId)
    {
        foreach (var entity in _db.ProjectEntities.AsNoTracking().Where(a => a.ProjectId == projectId).ToList())
            yield return new ProjectQueryResultDto
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                ProjectName = entity.ProjectName,
                DateAdded = entity.DateAdded,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    ProjectQueryResultDto IProjectRepository.GetProject(string userId, int projectId)
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.UserId ==userId && a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Dette projekt findes ikke"); 

        return new ProjectQueryResultDto
        {
            Id = dbEntity.Id,
            ProjectId = dbEntity.ProjectId,
            ProjectName = dbEntity.ProjectName,
            DateAdded = dbEntity.DateAdded,
            UserId = dbEntity.UserId,
            RowVersion = dbEntity.RowVersion
        };
    }

    ProjectEntity IProjectRepository.Load(int id) // Load metoden er til at hente data for Commands (do-while?)
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen");

        return dbEntity;
    }

    void IProjectRepository.Update(ProjectEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }

    void IProjectRepository.Delete(ProjectEntity model)
    {
        _db.Remove(model);
        _db.SaveChanges();
    }
}