using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;
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
        var user = new UserEntity(request.UserId, request.Name, request.Phone, request.RoleId);
        _repository.Add(user);
    }
}