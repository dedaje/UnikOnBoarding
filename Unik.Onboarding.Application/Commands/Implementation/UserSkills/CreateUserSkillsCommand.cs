using Unik.Onboarding.Application.Commands.UserSkills;
using Unik.Onboarding.Application.Repositories.UserSkills;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.UserSkills;

public class CreateUserSkillsCommand : ICreateUserSkillsCommand
{
    private readonly IUserSkillsRepository _repository;

    public CreateUserSkillsCommand(IUserSkillsRepository repository)
    {
        _repository = repository;
    }

    void ICreateUserSkillsCommand.Create(UserSkillsCreateRequestDto request)
    {
        var userSkills = new UserSkillsEntity(request.UserId, request.SkillId);
        _repository.Add(userSkills);
    }
}