using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IOnboardingRepository
{
    void Add(OnboardingEntity onboarding);
    IEnumerable<OnboardingQueryResultDto> GetAllProjects();
    OnboardingQueryResultDto GetProject(int projectId);
    OnboardingEntity Load(int projectId);
    void Update(OnboardingEntity model);
}