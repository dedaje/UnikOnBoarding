using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;

namespace Unik.Onboarding.Application.Queries.Implementation.Onboarding;

public class OnboardingGetAllQuery : IOnboardingGetAllQuery
{
    private readonly IOnboardingRepository _repository;

    public OnboardingGetAllQuery(IOnboardingRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<OnboardingQueryResultDto> IOnboardingGetAllQuery.GetAllProjects(int userId)
    {
        return _repository.GetAllProjects(userId);
    }
}