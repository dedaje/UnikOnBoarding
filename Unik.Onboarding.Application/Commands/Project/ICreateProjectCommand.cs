namespace Unik.Onboarding.Application.Commands.Project;

public interface ICreateProjectCommand
{
    void Create(ProjectCreateRequestDto request);
}