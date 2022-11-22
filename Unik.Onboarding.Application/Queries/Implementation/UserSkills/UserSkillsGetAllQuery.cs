using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.UserSkills;

public class UserSkillsGetAllQuery : IUserSkillsGetAllQuery
{
    private readonly IUserSkillsRepository _repository;

    public UserSkillsGetAllQuery(IUserSkillsRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<UserSkillsQueryResultDto> IUserSkillsGetAllQuery.GetAllUserSkills(string userId)
    {
        return _repository.GetAllUserSkills(userId);
    }
}