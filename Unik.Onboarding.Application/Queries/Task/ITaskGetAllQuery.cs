namespace Unik.Onboarding.Application.Queries.Task;

public interface ITaskGetAllQuery
{
    IEnumerable<TaskQueryResultDto> GetAllTasks(int projectId);
}