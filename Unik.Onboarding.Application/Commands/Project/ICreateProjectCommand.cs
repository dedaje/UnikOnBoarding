namespace Unik.Onboarding.Application.Commands.Onboarding;

public interface ICreateProjectCommand
{
    void Create(ProjectCreateRequestDto request);
}