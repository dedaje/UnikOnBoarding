using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.Onboarding;

public interface IOnboardingRepository
{
    void Add(OnboardingEntity onboarding);
    IEnumerable<OnboardingQueryResultDto> GetAllProjects();
    OnboardingEntity Load(int projectId);
    void Update(OnboardingEntity model);
    OnboardingQueryResultDto GetProject(int projectId);
}