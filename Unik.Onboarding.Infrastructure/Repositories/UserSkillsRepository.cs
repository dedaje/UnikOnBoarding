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
        throw new NotImplementedException();
    }

    UserSkillsQueryResultDto IUserSkillsRepository.GetUserSkill(int userId, int skillId)
    {
        throw new NotImplementedException();
    }

    UserSkillsEntity IUserSkillsRepository.Load(int userId, int skillId)
    {
        throw new NotImplementedException();
    }

    void IUserSkillsRepository.Update(UserSkillsEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}