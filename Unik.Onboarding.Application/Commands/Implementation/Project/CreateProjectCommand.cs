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
    private readonly IUserRepository _userRepository;

    public CreateProjectCommand(IProjectRepository repository, IProjectDomainService domainService, IUserRepository userRepository)
    {
        _repository = repository;
        _domainService = domainService;
        _userRepository = userRepository;
    }

    void ICreateProjectCommand.Create(ProjectCreateWithUserRequestDto request)
    {
        var projectId = new ProjectEntity(request.ProjectCreateDto.ProjectName, _domainService);
        var initialUserId = _userRepository.LoadUser(request.UserQueryDto.UserId);

        _repository.CreateWithInitialUser(initialUserId, projectId);
    }
}