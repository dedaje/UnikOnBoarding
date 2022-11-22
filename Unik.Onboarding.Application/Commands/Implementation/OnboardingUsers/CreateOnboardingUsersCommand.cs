using Unik.Onboarding.Application.Commands.OnboardingUsers;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.OnboardingUsers;

public class CreateOnboardingUsersCommand : ICreateOnboardingUsersCommand
{
    private readonly IOnboardingUsersRepository _repository;

    public CreateOnboardingUsersCommand(IOnboardingUsersRepository repository)
    {
        _repository = repository;
    }

    void ICreateOnboardingUsersCommand.Create(OnboardingUsersCreateRequestDto request)
    {
        var onboardingUser = new OnboardingUsersEntity(request.ProjectId, request.UserId);
        _repository.Add(onboardingUser);
    }
}