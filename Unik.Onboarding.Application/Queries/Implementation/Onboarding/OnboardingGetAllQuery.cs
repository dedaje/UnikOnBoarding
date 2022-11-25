using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Onboarding;

public class OnboardingGetAllQuery : IProjectGetAllQuery
{
    private readonly IProjectRepository _repository;

    public OnboardingGetAllQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<ProjectQueryResultDto> IProjectGetAllQuery.GetAllProjects()
    {
        return _repository.GetAllProjects();
    }
}