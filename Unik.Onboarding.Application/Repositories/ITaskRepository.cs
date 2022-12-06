using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface ITaskRepository
{
    void Add(TaskEntity task);
    IEnumerable<TaskQueryResultDto> GetAllTasksByRole(int projectId, int roleId);
    IEnumerable<TaskQueryResultDto> GetAllTasksByUser(int projectId, string userId);
    TaskQueryResultDto GetTask(int taskId);
    TaskEntity Load(int taskId);
    void Update(TaskEntity model);
    void Delete(TaskEntity model);
}