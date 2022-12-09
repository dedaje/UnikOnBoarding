namespace Unik.Onboarding.Application.Commands.ProjectUsers;

public interface IRemoveUserFromProjectCommand
{
    void RemoveUserFromProject(string userId, int projectId);
}