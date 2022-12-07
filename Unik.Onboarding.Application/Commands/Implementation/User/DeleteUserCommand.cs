using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.User;

public class DeleteUserCommand : IDeleteUserCommand
{
    private readonly IUserRepository _repository;

    public DeleteUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void IDeleteUserCommand.DeleteUser(string userId)
    {
        var user = _repository.LoadUser(userId);

        _repository.DeleteUser(user);
    }
}