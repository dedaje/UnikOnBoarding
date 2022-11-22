using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly UnikDbContext _db;

    public TaskRepository(UnikDbContext db)
    {
        _db = db;
    }

    void ITaskRepository.Add(TaskEntity task)
    {
        _db.Add(task);
        _db.SaveChanges();
    }

    IEnumerable<TaskQueryResultDto> ITaskRepository.GetAllTasksByRole(int projectId, int roleId)
    {
        foreach (var entity in _db.TaskEntities.AsNoTracking()
                     .Where(a => a.ProjectId == projectId && a.RoleId == roleId).ToList())
            yield return new TaskQueryResultDto
            {
                TaskId = entity.TaskId,
                TaskName = entity.TaskName,
                TaskDescription = entity.TaskDescription,
                DateCreated = entity.DateCreated,
                ProjectId = entity.ProjectId,
                RoleId = entity.RoleId,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    IEnumerable<TaskQueryResultDto> ITaskRepository.GetAllTasksByUser(int projectId, string userId)
    {
        foreach (var entity in _db.TaskEntities.AsNoTracking()
                     .Where(a => a.ProjectId == projectId && a.UserId == userId).ToList())
            yield return new TaskQueryResultDto
            {
                TaskId = entity.TaskId,
                TaskName = entity.TaskName,
                TaskDescription = entity.TaskDescription,
                DateCreated = entity.DateCreated,
                ProjectId = entity.ProjectId,
                RoleId = entity.RoleId,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    TaskQueryResultDto ITaskRepository.GetTask(int taskId)
    {
        var dbEntity = _db.TaskEntities.AsNoTracking().FirstOrDefault(a => a.TaskId == taskId);
        if (dbEntity == null) throw new Exception("Denne opgave findes ikke i dette projekt");

        return new TaskQueryResultDto
        {
            TaskId = dbEntity.TaskId,
            TaskName = dbEntity.TaskName,
            TaskDescription = dbEntity.TaskDescription,
            DateCreated = dbEntity.DateCreated,
            ProjectId = dbEntity.ProjectId,
            RoleId = dbEntity.RoleId,
            UserId = dbEntity.UserId,
            RowVersion = dbEntity.RowVersion
        };
    }

    TaskEntity ITaskRepository.Load(int taskId)
    {
        var dbEntity = _db.TaskEntities.AsNoTracking().FirstOrDefault(a => a.TaskId == taskId);
        if (dbEntity == null) throw new Exception("Den opgave findes ikke i databasen");

        return dbEntity;
    }

    void ITaskRepository.Update(TaskEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}