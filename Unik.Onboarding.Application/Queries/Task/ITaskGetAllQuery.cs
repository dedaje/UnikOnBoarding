namespace Unik.Onboarding.Application.Queries.Task;

public interface ITaskGetAllQuery
{
    IEnumerable<TaskQueryResultDto> GetAllTasksByRole(int projectId, int roleId);
    IEnumerable<TaskQueryResultDto> GetAllTasksByUser(int projectId, string userId);
}