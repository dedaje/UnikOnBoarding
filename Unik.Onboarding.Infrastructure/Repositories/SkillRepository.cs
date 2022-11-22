using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Skill;
using Unik.Onboarding.Application.Repositories;
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
        foreach (var entity in _db.SkillsEntities.AsNoTracking().ToList())
            yield return new SkillQueryResultDto
            {
                SkillId = entity.SkillId,
                SkillName = entity.SkillName,
                RowVersion = entity.RowVersion
            };
    }

    SkillQueryResultDto ISkillRepository.GetSkill(int skillId)
    {
        var dbEntity = _db.SkillsEntities.AsNoTracking().FirstOrDefault(a => a.SkillId == skillId);
        if (dbEntity == null) throw new Exception("Denne kompetence findes ikke i databasen");

        return new SkillQueryResultDto
        {
            SkillId = dbEntity.SkillId,
            SkillName = dbEntity.SkillName,
            RowVersion = dbEntity.RowVersion
        };
    }

    SkillsEntity ISkillRepository.Load(int skillId)
    {
        var dbEntity = _db.SkillsEntities.AsNoTracking().FirstOrDefault(a => a.SkillId == skillId);
        if (dbEntity == null) throw new Exception("Denne kompetence findes ikke i databasen");

        return dbEntity;
    }

    void ISkillRepository.Update(SkillsEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}