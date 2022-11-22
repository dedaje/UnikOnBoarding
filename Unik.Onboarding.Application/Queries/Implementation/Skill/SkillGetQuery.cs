using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Skill;

public class SkillGetQuery : ISkillGetQuery
{
    private readonly ISkillRepository _repository;

    public SkillGetQuery(ISkillRepository repository)
    {
        _repository = repository;
    }

    SkillQueryResultDto ISkillGetQuery.GetSkill(int skillId)
    {
        return _repository.GetSkill(skillId);
    }
}