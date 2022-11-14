using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Repositories.OnboardingUsers;

namespace Unik.Onboarding.Application.Queries.Implementation.OnboardingUsers
{
    public class OnboardingUsersGetAllQuery : IOnboardingUsersGetAllQuery
    {
        private readonly IOnboardingUsersRepository _repository;

        public OnboardingUsersGetAllQuery(IOnboardingUsersRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<OnboardingUsersQueryResultDto> IOnboardingUsersGetAllQuery.GetAllOnboardingUsers(int projectId)
        {
            return _repository.GetAllOnboardingUsers(projectId);
        }
    }
}
