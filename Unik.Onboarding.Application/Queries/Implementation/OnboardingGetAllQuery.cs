using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation
{
    public class OnboardingGetAllQuery : IOnboardingGetAllQuery
    {
        private readonly IOnboardingRepository _repository;

        public OnboardingGetAllQuery(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<OnboardingQueryResultDto> IOnboardingGetAllQuery.GetAll(string userId)
        {
            return _repository.GetAll(userId);
        }
    }
}
