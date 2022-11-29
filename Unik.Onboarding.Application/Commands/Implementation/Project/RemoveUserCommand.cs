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

    void IRemoveUserCommand.RemoveUser(RemoveUserRequestDto request)
    {
        var model = _repository.Load(request.ProjectId, request.UserId);
        _repository.RemoveUser(model);
    }
}