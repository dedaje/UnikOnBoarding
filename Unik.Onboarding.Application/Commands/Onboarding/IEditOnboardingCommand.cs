using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Onboarding
{
    public interface IEditOnboardingCommand
    {
        void Edit(OnboardingEditRequestDto request);
    }
}
