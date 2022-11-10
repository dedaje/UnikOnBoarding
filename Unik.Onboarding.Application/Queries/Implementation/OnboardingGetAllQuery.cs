using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation;

public class OnboardingGetAllQuery : IOnboardingGetAllQuery
{
    private readonly IOnboardingRepository _repository;

    public OnboardingGetAllQuery(IOnboardingRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<OnboardingQueryResultDto> IOnboardingGetAllQuery.GetAll(string specificUserId)
    {
        return _repository.GetAll(specificUserId);
    }
}