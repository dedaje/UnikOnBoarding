namespace Unik.Onboarding.Application.Commands.User;

public interface IRemoveUserCommand
{
    void RemoveUser(string userId, int projectId);
}