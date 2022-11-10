using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands
{
    public interface IEditOnboardingCommand
    {
        void AddUser(OnboardingEditRequestDto onboardingEditRequestDto);
        void Edit(OnboardingEditRequestDto onboardingEditRequestDto);
        void RemoveUser(OnboardingEditRequestDto onboardingEditRequestDto);
    }
}
