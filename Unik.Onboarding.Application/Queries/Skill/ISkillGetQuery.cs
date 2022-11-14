using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Skill
{
    public interface ISkillGetQuery
    {
        SkillQueryResultDto GetSkill(int skillId);
    }
}
