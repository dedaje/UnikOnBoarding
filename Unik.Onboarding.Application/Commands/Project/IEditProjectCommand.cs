namespace Unik.Onboarding.Application.Commands.Project;

public interface IEditProjectCommand
{
    void Edit(ProjectEditRequestDto request);
}