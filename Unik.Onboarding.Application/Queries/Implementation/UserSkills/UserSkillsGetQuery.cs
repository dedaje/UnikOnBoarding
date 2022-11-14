using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Application.Repositories.UserSkills;

namespace Unik.Onboarding.Application.Queries.Implementation.UserSkills
{
    public class UserSkillsGetQuery : IUserSkillsGetQuery
    {
        private readonly IUserSkillsRepository _repository;

        public UserSkillsGetQuery(IUserSkillsRepository repository)
        {
            _repository = repository;
        }

        UserSkillsQueryResultDto IUserSkillsGetQuery.GetUserSkill(int userId, int skillId)
        {
            return _repository.GetUserSkill(userId, skillId);
        }
    }
}
