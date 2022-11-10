using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation
{
    public class OnboardingGetQuery : IOnboardingGetQuery
    {
        private readonly IOnboardingRepository _repository;

        public OnboardingGetQuery(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        OnboardingQueryResultDto IOnboardingGetQuery.Get(int id, string specificUserId)
        {
            return _repository.Get(id, specificUserId);
        }
    }
}
