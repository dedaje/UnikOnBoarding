using Unik.Onboarding.Application.Queries.Task;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Task;

public class TaskGetAllQuery : ITaskGetAllQuery
{
    private readonly ITaskRepository _repository;

    public TaskGetAllQuery(ITaskRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<TaskQueryResultDto> ITaskGetAllQuery.GetAllTasks(int projectId)
    {
        return _repository.GetAllTasks(projectId);

        //throw new NotImplementedException();
    }
}