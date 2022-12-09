namespace Unik.Onboarding.Application.Commands.ProjectUsers;

public interface IAddUserToProjectCommand
{
    void AddUser(ProjectAddUserRequestDto request);
}