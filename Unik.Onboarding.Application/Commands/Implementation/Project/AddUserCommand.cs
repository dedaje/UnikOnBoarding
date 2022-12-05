using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class AddUserCommand : IAddUserCommand
{
    private readonly IUserRepository _repository;
    private readonly IProjectDomainService _domainService;

    public AddUserCommand(IUserRepository repository, IProjectDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    void IAddUserCommand.AddUser(AddUserRequestDto request)
    {
        var addUser = new ProjectEntity(request.ProjectId, request.ProjectName, request.UserId, _domainService);
        _repository.AddUser(addUser);
    }
}