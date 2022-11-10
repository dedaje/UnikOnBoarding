using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Domain.DomainServices
{
    public interface IOnboardingDomainService
    {
        bool userExistsInProject(int id, List<string> userId, string specificUserId);
    }
}
