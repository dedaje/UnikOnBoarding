using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.User;

public class RemoveUserCommand : IRemoveUserCommand
{
    private readonly IUserRepository _repository;

    public RemoveUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void IRemoveUserCommand.RemoveUser(string userId, int projectId)
    {
        //var model = _repository.Load(userId, projectId);

        //_repository.RemoveUser(model);

        throw new NotImplementedException();
    }
}