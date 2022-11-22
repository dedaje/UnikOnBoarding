using Unik.Onboarding.Application.Commands.OnboardingUsers;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.OnboardingUsers;

public class EditOnboardingUsersCommand : IEditOnboardingUsersCommand
{
    private readonly IOnboardingUsersRepository _repository;

    public EditOnboardingUsersCommand(IOnboardingUsersRepository repository)
    {
        _repository = repository;
    }

    void IEditOnboardingUsersCommand.Edit(OnboardingUsersEditRequestDto request)
    {
        //Read
        var model = _repository.Load(request.ProjectId, request.UserId);

        //DoIt
        model.Edit(request.ProjectId, request.UserId, request.RowVersion);

        //Save
        _repository.Update(model);
    }
}