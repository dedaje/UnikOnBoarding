namespace Unik.Onboarding.Application.Commands.User;

public interface IEditUserCommand
{
    void Edit(UserEditRequestDto request);
}