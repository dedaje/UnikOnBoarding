using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Application.Repositories.Skill;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly UnikDbContext _db;

    public SkillRepository(UnikDbContext db)
    {
        _db = db;
    }

    void ISkillRepository.Add(SkillsEntity skill)
    {
        _db.Add(skill);
        _db.SaveChanges();
    }

    IEnumerable<SkillQueryResultDto> ISkillRepository.GetAllSkills()
    {
        throw new NotImplementedException();
    }

    SkillQueryResultDto ISkillRepository.GetSkill(int skillId)
    {
        throw new NotImplementedException();
    }

    SkillsEntity ISkillRepository.Load(int skillId)
    {
        throw new NotImplementedException();
    }

    void ISkillRepository.Update(SkillsEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}