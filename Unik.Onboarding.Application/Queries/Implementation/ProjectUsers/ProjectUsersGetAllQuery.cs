using Unik.Onboarding.Application.Queries.ProjectUsers;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.ProjectUsers;

public class ProjectUsersGetAllQuery : IProjectUsersGetAllQuery
{
    private readonly IProjectRepository _repository;

    public ProjectUsersGetAllQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<ProjectUsersQueryResultDto> IProjectUsersGetAllQuery.GetAllProjectUsers(int projectId)
    {
        return _repository.GetAllProjectUsers(projectId);
    }
}