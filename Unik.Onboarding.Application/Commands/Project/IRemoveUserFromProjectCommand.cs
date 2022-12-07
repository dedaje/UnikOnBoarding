namespace Unik.Onboarding.Application.Commands.Project;

public interface IRemoveUserFromProjectCommand
{
    void RemoveUserFromProject(string userId, int projectId);
}