using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Project;

public class ProjectGetAllQuery : IProjectGetAllQuery
{
    private readonly IProjectRepository _repository;

    public ProjectGetAllQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<ProjectQueryResultDto> IProjectGetAllQuery.GetAllUserProjects(string userId)
    {
        return _repository.GetAllUserProjects(userId);
    }

    IEnumerable<ProjectQueryResultDto> IProjectGetAllQuery.GetAllEditProjects(int? projectId)
    {
        return _repository.GetAllEditProjects(projectId);
    }
}