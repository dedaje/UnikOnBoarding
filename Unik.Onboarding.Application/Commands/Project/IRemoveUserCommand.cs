namespace Unik.Onboarding.Application.Commands.Project;

public interface IRemoveUserCommand
{
    void RemoveUser(string userId, int projectId);
}