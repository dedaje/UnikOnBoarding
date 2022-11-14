using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.Skill;

public interface ISkillRepository
{
    void Add(SkillsEntity skill);
    IEnumerable<SkillQueryResultDto> GetAllSkills();
    SkillsEntity Load(int skillId);
    void Update(SkillsEntity model);
    SkillQueryResultDto GetSkill(int skillId);
}