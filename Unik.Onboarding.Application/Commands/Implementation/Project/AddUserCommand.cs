using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class AddUserCommand : IAddUserCommand
{
    private readonly IUserRepository _repository;

    public AddUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void IAddUserCommand.AddUser(AddUserRequestDto request)
    {
        var addUser = new ProjectEntity(request.ProjectId, request.ProjectName, request.UserId);
        _repository.AddUser(addUser);
    }
}