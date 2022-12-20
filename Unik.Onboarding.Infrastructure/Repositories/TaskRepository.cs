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

    void ITaskRepository.AddTask(TaskEntity task)
    {
        _db.Add(task);
        _db.SaveChanges();

        //throw new NotImplementedException();
    }

    IEnumerable<TaskQueryResultDto> ITaskRepository.GetAllTasks(int projectId)
    {
        foreach (var entity in _db.TaskEntities.AsNoTracking()
                     .Where(a => a.ProjectsId == projectId).ToList())
            yield return new TaskQueryResultDto
            {
                Id = entity.Id,
                TaskName = entity.TaskName,
                TaskDescription = entity.TaskDescription,
                DateCreated = entity.DateCreated,
                ProjectsId = entity.ProjectsId,
                Section = entity.Section,
                UsersId = entity.UsersId,
                RowVersion = entity.RowVersion
            };

        //throw new NotImplementedException();
    }

    TaskQueryResultDto ITaskRepository.GetTask(int taskId)
    {
        var dbEntity = _db.TaskEntities.AsNoTracking().FirstOrDefault(a => a.Id == taskId);
        if (dbEntity == null) throw new Exception("Denne opgave findes ikke");

        return new TaskQueryResultDto
        {
            Id = dbEntity.Id,
            TaskName = dbEntity.TaskName,
            TaskDescription = dbEntity.TaskDescription,
            DateCreated = dbEntity.DateCreated,
            ProjectsId = dbEntity.ProjectsId,
            Section = dbEntity.Section,
            UsersId = dbEntity.UsersId,
            RowVersion = dbEntity.RowVersion
        };

        //throw new NotImplementedException();
    }

    TaskEntity ITaskRepository.LoadTask(int taskId)
    {
        var dbEntity = _db.TaskEntities.AsNoTracking().FirstOrDefault(a => a.Id == taskId);
        if (dbEntity == null) throw new Exception("Den opgave findes ikke i databasen");

        return dbEntity;

        //throw new NotImplementedException();
    }

    void ITaskRepository.UpdateTask(TaskEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();

        //throw new NotImplementedException();
    }

    void ITaskRepository.DeleteTask(TaskEntity model)
    {
        _db.Remove(model);
        _db.SaveChanges();

        //throw new NotImplementedException();
    }
}