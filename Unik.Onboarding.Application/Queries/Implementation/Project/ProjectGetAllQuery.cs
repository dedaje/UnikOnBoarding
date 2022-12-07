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

    IEnumerable<ProjectUsersQueryResultDto> IProjectGetAllQuery.GetAllUserProjects(int projectId, int usersId)
    {
        return _repository.GetAllUserProjects(projectId, usersId);
        //throw new NotImplementedException();
    }

    IEnumerable<ProjectQueryResultDto> IProjectGetAllQuery.GetAllProjects()
    {
        return _repository.GetAllProjects();
        //throw new NotImplementedException();
    }
}