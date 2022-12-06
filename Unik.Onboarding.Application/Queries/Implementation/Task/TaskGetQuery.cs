using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Task;

public class TaskGetQuery : ITaskGetQuery
{
    private readonly ITaskRepository _repository;

    public TaskGetQuery(ITaskRepository repository)
    {
        _repository = repository;
    }

    TaskQueryResultDto ITaskGetQuery.GetTask(int taskId)
    {
        //return _repository.GetTask(taskId);

        throw new NotImplementedException();
    }
}