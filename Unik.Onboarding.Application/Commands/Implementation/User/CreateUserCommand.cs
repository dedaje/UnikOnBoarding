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

    void ICreateUserCommand.CreateUser(UserCreateRequestDto request)
    {
        var addUser = new UsersEntity(request.UserId);
        _repository.CreateUser(addUser);
    }
}