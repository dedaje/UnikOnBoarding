using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface ITaskRepository
{
    void AddTask(TaskEntity task);
    IEnumerable<TaskQueryResultDto> GetAllTasks(int projectId);
    TaskQueryResultDto GetTask(int taskId);
    TaskEntity LoadTask(int taskId);
    void UpdateTask(TaskEntity model);
    void DeleteTask(TaskEntity model);
}