namespace Unik.Onboarding.Application.Commands.User;

public interface ICreateUserCommand
{
    void CreateUser(UserCreateRequestDto request);
}