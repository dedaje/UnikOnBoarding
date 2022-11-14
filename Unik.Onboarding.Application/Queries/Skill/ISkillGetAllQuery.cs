using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Skill
{
    public interface ISkillGetAllQuery
    {
        IEnumerable<SkillQueryResultDto> GetAllSkills();
    }
}
