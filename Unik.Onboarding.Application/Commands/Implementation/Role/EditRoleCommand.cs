using Unik.Onboarding.Application.Commands.Role;
using Unik.Onboarding.Application.Repositories.Role;

namespace Unik.Onboarding.Application.Commands.Implementation.Role;

public class EditRoleCommand : IEditRoleCommand
{
    private readonly IRoleRepository _repository;

    public EditRoleCommand(IRoleRepository repository)
    {
        _repository = repository;
    }

    void IEditRoleCommand.Edit(RoleEditRequestDto request)
    {
        //Read
        var model = _repository.Load(request.RoleId);

        //DoIt
        model.Edit(request.RoleName, request.RowVersion);

        //Save
        _repository.Update(model);
    }
}