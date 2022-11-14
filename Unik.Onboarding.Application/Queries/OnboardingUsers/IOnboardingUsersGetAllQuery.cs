using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.OnboardingUsers
{
    public interface IOnboardingUsersGetAllQuery
    {
        IEnumerable<OnboardingUsersQueryResultDto> GetAllOnboardingUsers(int projectId);
    }
}
