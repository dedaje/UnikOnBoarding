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

    IEnumerable<TaskQueryResultDto> ITaskGetAllQuery.GetAllTasksByRole(int projectId, int roleId)
    {
        //return _repository.GetAllTasksByRole(projectId, roleId);

        throw new NotImplementedException();
    }

    IEnumerable<TaskQueryResultDto> ITaskGetAllQuery.GetAllTasksByUser(int projectId, string userId)
    {
        //return _repository.GetAllTasksByUser(projectId, userId);

        throw new NotImplementedException();
    }
}