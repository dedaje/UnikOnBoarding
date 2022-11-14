using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Repositories.OnboardingUsers;

namespace Unik.Onboarding.Application.Queries.Implementation.OnboardingUsers
{
    public class OnboardingUsersGetQuery : IOnboardingUsersGetQuery
    {
        private readonly IOnboardingUsersRepository _repository;

        public OnboardingUsersGetQuery(IOnboardingUsersRepository repository)
        {
            _repository = repository;
        }

        OnboardingUsersQueryResultDto IOnboardingUsersGetQuery.GetOnboardingUser(int projectId, int userId)
        {
            return _repository.GetOnboardingUser(projectId, userId);
        }
    }
}
