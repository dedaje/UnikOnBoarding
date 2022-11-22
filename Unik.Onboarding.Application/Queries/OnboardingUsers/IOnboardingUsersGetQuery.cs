namespace Unik.Onboarding.Application.Queries.OnboardingUsers;

public interface IOnboardingUsersGetQuery
{
    OnboardingUsersQueryResultDto GetOnboardingUser(int projectId, string userId);
}