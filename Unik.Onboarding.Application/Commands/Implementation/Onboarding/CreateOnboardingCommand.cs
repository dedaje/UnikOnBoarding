using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Onboarding;

public class CreateOnboardingCommand : ICreateOnboardingCommand
{
    private readonly IOnboardingRepository _onboardingRepository;

    public CreateOnboardingCommand(
        IOnboardingRepository onboardingRepository)
    {
        _onboardingRepository = onboardingRepository;
    }

    void ICreateOnboardingCommand.Create(OnboardingCreateRequestDto onboardingCreateRequestDto)
    {
        var onboarding = new OnboardingEntity(onboardingCreateRequestDto.ProjectName);
        _onboardingRepository.Add(onboarding);
    }
}