namespace Unik.Onboarding.Application.Queries.UserSkills;

public interface IUserSkillsGetQuery
{
    UserSkillsQueryResultDto GetUserSkill(string userId, int skillId);
}