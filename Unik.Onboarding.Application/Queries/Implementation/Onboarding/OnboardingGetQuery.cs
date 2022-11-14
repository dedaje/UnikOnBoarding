using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;

namespace Unik.Onboarding.Application.Queries.Implementation.Onboarding
{
    public class OnboardingGetQuery : IOnboardingGetQuery
    {
        private readonly IOnboardingRepository _repository;

        public OnboardingGetQuery(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        OnboardingQueryResultDto IOnboardingGetQuery.GetProject(int projectId, int userId)
        {
            return _repository.GetProject(projectId, userId);
        }
    }
}
