namespace Unik.Onboarding.Application.Commands.User;

public interface IAddUserCommand
{
    void AddUser(AddUserRequestDto request);
}