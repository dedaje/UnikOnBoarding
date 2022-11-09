using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Domain.Model.DomainServices;

namespace Unik.Onboarding.Domain.Model
{
    public class OnboardingEntity
    {
        private readonly IOnboardingDomainService _domainService;

        internal OnboardingEntity()
        {

        }

        public OnboardingEntity(IOnboardingDomainService domainService, string userId)
        {
            _domainService = domainService;
            UserId = userId;
        }

        public int Id { get; }
        public string UserId { get; private set; }
        public DateTime Date { get; private set; }
    }
}
