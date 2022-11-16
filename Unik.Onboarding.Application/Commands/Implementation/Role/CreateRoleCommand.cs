using Unik.Onboarding.Application.Commands.Role;
using Unik.Onboarding.Application.Repositories.Role;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Role;

public class CreateRoleCommand : ICreateRoleCommand
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommand(IRoleRepository repository)
    {
        _repository = repository;
    }

    void ICreateRoleCommand.Create(RoleCreateRequestDto request)
    {
        var role = new RoleEntity(request.RoleName);
        _repository.Add(role);
    }
}