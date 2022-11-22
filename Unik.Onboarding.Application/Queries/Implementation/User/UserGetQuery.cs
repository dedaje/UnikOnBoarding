using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.User;

public class UserGetQuery : IUserGetQuery
{
    private readonly IUserRepository _repository;

    public UserGetQuery(IUserRepository repository)
    {
        _repository = repository;
    }

    UserQueryResultDto IUserGetQuery.GetUser(string userId)
    {
        return _repository.GetUser(userId);
    }
}