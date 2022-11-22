using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.OnboardingUsers;

public class OnboardingUsersGetQuery : IOnboardingUsersGetQuery
{
    private readonly IOnboardingUsersRepository _repository;

    public OnboardingUsersGetQuery(IOnboardingUsersRepository repository)
    {
        _repository = repository;
    }

    OnboardingUsersQueryResultDto IOnboardingUsersGetQuery.GetOnboardingUser(int projectId, string userId)
    {
        return _repository.GetOnboardingUser(projectId, userId);
    }
}