using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Onboarding
{
    public interface IOnboardingGetQuery
    {
        OnboardingQueryResultDto GetProject(int projectId, int userId); // This Gets a logged in user's specific project they're assigned to
    }
}
