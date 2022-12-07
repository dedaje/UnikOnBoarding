namespace Unik.Onboarding.Application.Commands.Project;

public interface IDeleteProjectCommand
{
    void Delete(int projectId);
    //void Delete(ProjectDeleteRequestDto request);
}