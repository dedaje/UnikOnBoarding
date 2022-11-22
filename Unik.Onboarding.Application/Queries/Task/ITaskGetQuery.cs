namespace Unik.Onboarding.Application.Queries.Task;

public interface ITaskGetQuery
{
    TaskQueryResultDto GetTask(int taskId);
}