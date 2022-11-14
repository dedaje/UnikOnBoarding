using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.UserSkills
{
    public interface IUserSkillsRepository
    {
        void Add(UserSkillsEntity userSkill);
        IEnumerable<UserSkillsQueryResultDto> GetAllUserSkills(int userId);
        UserSkillsEntity Load(int userId, int skillId);
        void Update(UserSkillsEntity model);
        UserSkillsQueryResultDto GetUserSkill(int userId, int skillId);
    }
}
