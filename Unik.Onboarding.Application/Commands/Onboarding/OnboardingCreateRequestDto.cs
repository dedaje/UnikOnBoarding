using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Onboarding
{
    public class OnboardingCreateRequestDto
    {
        public List<string> UserId { get; set; }
        public string? SpecificUserId { get; set; }
        public string ProjektNavn { get; set; }
    }
}
