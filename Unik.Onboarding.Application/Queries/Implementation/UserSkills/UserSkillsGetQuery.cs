using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.UserSkills;

public class UserSkillsGetQuery : IUserSkillsGetQuery
{
    private readonly IUserSkillsRepository _repository;

    public UserSkillsGetQuery(IUserSkillsRepository repository)
    {
        _repository = repository;
    }

    UserSkillsQueryResultDto IUserSkillsGetQuery.GetUserSkill(string userId, int skillId)
    {
        return _repository.GetUserSkill(userId, skillId);
    }
}