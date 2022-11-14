using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.OnboardingUsers
{
    public interface IOnboardingUsersRepository
    {
        void Add(OnboardingUsersEntity onboardingUsers);
        IEnumerable<OnboardingUsersQueryResultDto> GetAllOnboardingUsers(int projectId);
        OnboardingUsersEntity Load(int projectId, int userId);
        void Update(OnboardingUsersEntity model);
        OnboardingUsersQueryResultDto GetOnboardingUser(int projectId, int userId);
    }
}
