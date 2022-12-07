using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.User;

public class CreateUserCommand : ICreateUserCommand
{
    private readonly IUserRepository _repository;
    //private readonly IUsersDomainService _domainService;

    public CreateUserCommand(IUserRepository repository/*, IUsersDomainService domainService*/)
    {
        _repository = repository;
        //_domainService = domainService;
    }

    void ICreateUserCommand.CreateUser(UserCreateRequestDto request)
    {
        var addUser = new UsersEntity(request.UserId/*, _domainService*/);
        _repository.CreateUser(addUser);

        //throw new NotImplementedException();
    }
}