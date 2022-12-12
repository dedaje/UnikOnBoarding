using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.ProjectUsers;
using Unik.Onboarding.Application.Queries.UserProjects;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Project;

public class ProjectGetAllQuery : IProjectGetAllQuery
{
    private readonly IProjectRepository _repository;

    public ProjectGetAllQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<ProjectUsersQueryResultDto> IProjectGetAllQuery.GetAllProjectUsers(int projectId)
    {
        return _repository.GetAllProjectUsers(projectId);
        //throw new NotImplementedException();
    }

    IEnumerable<ProjectQueryResultDto> IProjectGetAllQuery.GetAllProjects()
    {
        return _repository.GetAllProjects();
        //throw new NotImplementedException();
    }
}