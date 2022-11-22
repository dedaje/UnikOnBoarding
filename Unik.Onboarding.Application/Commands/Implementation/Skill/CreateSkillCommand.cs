using Unik.Onboarding.Application.Commands.Skill;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Skill;

public class CreateSkillCommand : ICreateSkillCommand
{
    private readonly ISkillRepository _repository;

    public CreateSkillCommand(ISkillRepository repository)
    {
        _repository = repository;
    }

    void ICreateSkillCommand.Create(SkillCreateRequestDto request)
    {
        var skill = new SkillsEntity(request.SkillName);
        _repository.Add(skill);
    }
}