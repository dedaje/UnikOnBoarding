using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface ISkillRepository
{
    void Add(SkillsEntity skill);
    IEnumerable<SkillQueryResultDto> GetAllSkills();
    SkillQueryResultDto GetSkill(int skillId);
    SkillsEntity Load(int skillId);
    void Update(SkillsEntity model);
}