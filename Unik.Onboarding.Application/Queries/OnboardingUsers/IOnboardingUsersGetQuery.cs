using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.OnboardingUsers
{
    public interface IOnboardingUsersGetQuery
    {
        OnboardingUsersQueryResultDto GetOnboardingUser(int projectId, int userId);
    }
}
