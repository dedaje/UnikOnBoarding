using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IOnboardingUsersRepository
{
    void Add(OnboardingUsersEntity onboardingUsers);
    IEnumerable<OnboardingUsersQueryResultDto> GetAllOnboardingUsers(int projectId);
    OnboardingUsersQueryResultDto GetOnboardingUser(int projectId, string userId);
    OnboardingUsersEntity Load(int projectId, string userId);
    void Update(OnboardingUsersEntity model);
}