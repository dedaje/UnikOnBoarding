using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Onboarding;

public class OnboardingGetQuery : IProjectGetQuery
{
    private readonly IProjectRepository _repository;

    public OnboardingGetQuery(IProjectRepository repository)
    {
        _repository = repository;
    }

    ProjectQueryResultDto IProjectGetQuery.GetProject(int projectId)
    {
        return _repository.GetProject(projectId);
    }
}