using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation
{
    public class CreateOnboardingCommand : ICreateOnboardingCommand
    {
        private readonly IOnboardingRepository _onboardingRepository;
        private readonly IOnboardingDomainService _domainService;

        public CreateOnboardingCommand(IOnboardingRepository onboardingRepository, IOnboardingDomainService domainService)
        {
            _onboardingRepository = onboardingRepository;
            _domainService = domainService;
        }

        void ICreateOnboardingCommand.Create(OnboardingCreateRequestDto onboardingCreateRequestDto)
        {
            var onboarding = new OnboardingEntity(/*_domainService,*/ onboardingCreateRequestDto.ProjektNavn);
            _onboardingRepository.Add(onboarding);
        }
    }
}
