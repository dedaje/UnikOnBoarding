using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Application.Repositories.UserSkills;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class UserSkillsRepository : IUserSkillsRepository
{
    private readonly UnikDbContext _db;

    public UserSkillsRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IUserSkillsRepository.Add(UserSkillsEntity userSkill)
    {
        _db.Add(userSkill);
        _db.SaveChanges();
    }

    IEnumerable<UserSkillsQueryResultDto> IUserSkillsRepository.GetAllUserSkills(int userId)
    {
        foreach (var entity in _db.UserSkillsEntities.AsNoTracking().Where(a => a.UserId == userId).ToList())
            yield return new UserSkillsQueryResultDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                SkillId = entity.SkillId,
                RowVersion = entity.RowVersion
            };
    }

    UserSkillsQueryResultDto IUserSkillsRepository.GetUserSkill(int userId, int skillId)
    {
        var dbEntity = _db.UserSkillsEntities.AsNoTracking()
            .FirstOrDefault(a => a.UserId == userId && a.SkillId == skillId);
        if (dbEntity == null) throw new Exception("Denne bruger har ikke denne kompetence");

        return new UserSkillsQueryResultDto
        {
            Id = dbEntity.Id,
            UserId = dbEntity.UserId,
            SkillId = dbEntity.SkillId,
            RowVersion = dbEntity.RowVersion
        };
    }

    UserSkillsEntity IUserSkillsRepository.Load(int userId, int skillId)
    {
        var dbEntity = _db.UserSkillsEntities.AsNoTracking()
            .FirstOrDefault(a => a.UserId == userId && a.SkillId == skillId);
        if (dbEntity == null) throw new Exception("Denne bruger har ikke denne kompetence");

        return dbEntity;
    }

    void IUserSkillsRepository.Update(UserSkillsEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}