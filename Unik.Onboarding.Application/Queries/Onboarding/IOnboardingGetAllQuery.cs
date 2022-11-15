using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Onboarding
{
    public interface IOnboardingGetAllQuery
    {
        //Gets all the projects that the logged in user is assigned to
        IEnumerable<OnboardingQueryResultDto> GetAllProjects(); // This GetAll needs the userId of the user that's logged in currently
    }
}
