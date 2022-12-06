using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class CreateProjectCommand : ICreateProjectCommand
{
    private readonly IProjectRepository _repository;
    private readonly IProjectDomainService _domainService;

    public CreateProjectCommand(IProjectRepository repository, IProjectDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    void ICreateProjectCommand.Create(ProjectCreateWithUserRequestDto request)
    {
        var project = new ProjectEntity(request.ProjectCreateRequestDto.Users, request.ProjectCreateRequestDto.ProjectName, _domainService);
        var initialUser = new UsersEntity(request.AddUserRequestDto.Projects, request.AddUserRequestDto.UserId);
        _repository.Add(project, initialUser);

        //throw new NotImplementedException();
    }
}