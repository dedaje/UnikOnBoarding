using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.User;

public class EditUserCommand : IEditUserCommand
{
    private readonly IUserRepository _repository;

    public EditUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void IEditUserCommand.Edit(UserEditRequestDto request)
    {
        //Read
        var model = _repository.Load(request.Id);

        //DoIt
        model.Edit(request.UserId, request.Name, request.Phone, request.RoleId, request.RowVersion);

        //Save
        _repository.Update(model);
    }
}