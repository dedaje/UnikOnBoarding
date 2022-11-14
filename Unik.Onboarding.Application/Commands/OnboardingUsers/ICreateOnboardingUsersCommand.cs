using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.OnboardingUsers
{
    public interface ICreateOnboardingUsersCommand
    {
        void Create(OnboardingUsersCreateRequestDto request);
    }
}
