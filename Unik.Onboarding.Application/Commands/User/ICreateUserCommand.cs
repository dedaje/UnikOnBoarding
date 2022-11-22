namespace Unik.Onboarding.Application.Commands.User;

public interface ICreateUserCommand
{
    void Create(UserCreateRequestDto request);
}