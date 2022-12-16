using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class DeleteProjectCommand : IDeleteProjectCommand
{
    private readonly IProjectRepository _repository;

    public DeleteProjectCommand(IProjectRepository repository)
    {
        _repository = repository;
    }

    void IDeleteProjectCommand.Delete(int projectId)
    {
        var model = _repository.LoadProject(projectId);

        _repository.DeleteProject(model);
    }
}