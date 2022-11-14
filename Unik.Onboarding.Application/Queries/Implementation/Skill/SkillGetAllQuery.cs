using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Application.Repositories.Skill;

namespace Unik.Onboarding.Application.Queries.Implementation.Skill
{
    public class SkillGetAllQuery : ISkillGetAllQuery
    {
        private readonly ISkillRepository _repository;

        public SkillGetAllQuery(ISkillRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<SkillQueryResultDto> ISkillGetAllQuery.GetAllSkills()
        {
            return _repository.GetAllSkills();
        }
    }
}
