using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Project;

public class ProjectGetQuery : IProjectGetQuery
{
    private readonly IProjectRepository _repository;

    public ProjectGetQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    ProjectQueryResultDto IProjectGetQuery.GetProject(string userId, int projectId)
    {
        //return _repository.GetProject(userId, projectId);

        throw new NotImplementedException();
    }
}