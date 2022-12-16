using Unik.Onboarding.Application.Queries.UserProjects;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.UserProjects;

public class UserProjectsGetAllQuery : IUserProjectsGetAllQuery
{
    private readonly IUserRepository _repository;

    public UserProjectsGetAllQuery(IUserRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<UserProjectsQueryResultDto> IUserProjectsGetAllQuery.GetAllUserProjects(int? usersId)
    {
        return _repository.GetAllUserProjects(usersId);
    }
}