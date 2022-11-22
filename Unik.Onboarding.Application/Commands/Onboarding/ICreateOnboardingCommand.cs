namespace Unik.Onboarding.Application.Commands.Onboarding;

public interface ICreateOnboardingCommand
{
    void Create(OnboardingCreateRequestDto request);
}