using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class RemoveUserCommand : IRemoveUserCommand
{
    private readonly IUserRepository _repository;

    public RemoveUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void IRemoveUserCommand.RemoveUser(string userId, int projectId)
    {
        var model = _repository.Load(userId, projectId);

        _repository.RemoveUser(model);
    }
}