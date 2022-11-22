using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Onboarding;

public class OnboardingGetQuery : IOnboardingGetQuery
{
    private readonly IOnboardingRepository _repository;

    public OnboardingGetQuery(IOnboardingRepository repository)
    {
        _repository = repository;
    }

    OnboardingQueryResultDto IOnboardingGetQuery.GetProject(int projectId)
    {
        return _repository.GetProject(projectId);
    }
}