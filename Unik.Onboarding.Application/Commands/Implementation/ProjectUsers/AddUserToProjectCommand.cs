using Unik.Onboarding.Application.Commands.ProjectUsers;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;

namespace Unik.Onboarding.Application.Commands.Implementation.ProjectUsers;

public class AddUserToProjectCommand : IAddUserToProjectCommand
{
    private readonly IUserDomainService _domainService;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;

    public AddUserToProjectCommand(IProjectRepository projectRepository, IUserDomainService domainService, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _domainService = domainService;
        _userRepository = userRepository;
    }

    void IAddUserToProjectCommand.AddUser(ProjectAddUserRequestDto request)
    {
        var project = _projectRepository.LoadProject(request.ProjectQueryDto.ProjectId);
        var user = _userRepository.LoadUser(request.UserQueryDto.UserId);

        _projectRepository.AddUserToProject(user, project);
    }
}