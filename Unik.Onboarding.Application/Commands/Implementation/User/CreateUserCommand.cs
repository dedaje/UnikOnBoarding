using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.User;

public class CreateUserCommand : ICreateUserCommand
{
    private readonly IUserRepository _repository;

    public CreateUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    void ICreateUserCommand.Create(UserCreateRequestDto request)
    {
        var user = new UserEntity(request.FirstName, request.LastName, request.Email, request.Phone, request.RoleId);
        _repository.Add(user);
    }
}