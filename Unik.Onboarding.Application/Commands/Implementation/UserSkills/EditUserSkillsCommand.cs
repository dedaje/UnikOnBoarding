using Unik.Onboarding.Application.Commands.UserSkills;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.UserSkills;

public class EditUserSkillsCommand : IEditUserSkillsCommand
{
    private readonly IUserSkillsRepository _repository;

    public EditUserSkillsCommand(IUserSkillsRepository repository)
    {
        _repository = repository;
    }

    void IEditUserSkillsCommand.Edit(UserSkillsEditRequestDto request)
    {
        //Read
        var model = _repository.Load(request.UserId, request.SkillId);

        //DoIt
        model.Edit(request.UserId, request.SkillId, request.RowVersion);

        //Save
        _repository.Update(model);
    }
}