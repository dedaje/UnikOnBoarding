namespace Unik.Onboarding.Application.Commands.Onboarding;

public interface IEditOnboardingCommand
{
    void Edit(OnboardingEditRequestDto request);
}