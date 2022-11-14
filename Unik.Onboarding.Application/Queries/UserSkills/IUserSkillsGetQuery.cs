using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.UserSkills
{
    public interface IUserSkillsGetQuery
    {
        UserSkillsQueryResultDto GetUserSkill(int userId, int skillId);
    }
}
