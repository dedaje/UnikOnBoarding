using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Onboarding;

public class EditOnboardingCommand : IEditOnboardingCommand
{
    private readonly IOnboardingRepository _repository;

    public EditOnboardingCommand(IOnboardingRepository repository)
    {
        _repository = repository;
    }

    void IEditOnboardingCommand.Edit(OnboardingEditRequestDto requestDto)
    {
        //Read
        var model = _repository.Load(requestDto.ProjectId);

        //DoIt
        model.Edit(requestDto.ProjectName, requestDto.RowVersion);

        //Save
        _repository.Update(model);
    }
}