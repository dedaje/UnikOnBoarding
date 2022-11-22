using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IUserSkillsRepository
{
    void Add(UserSkillsEntity userSkill);
    IEnumerable<UserSkillsQueryResultDto> GetAllUserSkills(string userId);
    UserSkillsQueryResultDto GetUserSkill(string userId, int skillId);
    UserSkillsEntity Load(string userId, int skillId);
    void Update(UserSkillsEntity model);
}