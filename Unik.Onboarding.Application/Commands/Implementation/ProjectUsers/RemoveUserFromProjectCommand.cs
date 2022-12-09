using Unik.Onboarding.Application.Commands.ProjectUsers;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.ProjectUsers;

public class RemoveUserFromProjectCommand : IRemoveUserFromProjectCommand
{
    private readonly IProjectRepository _repository;
    private readonly IUserRepository _userRepository;

    public RemoveUserFromProjectCommand(IProjectRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    void IRemoveUserFromProjectCommand.RemoveUserFromProject(string userId, int projectId /*ProjectRemoveUserRequestDto request*/)
    {
        var project = _repository.LoadProject(projectId);
        var user = _userRepository.LoadUser(userId);

        _repository.RemoveUserFromProject(user, project);
    }
}