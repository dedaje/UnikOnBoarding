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

    void IDeleteProjectCommand.Delete(int projectId /*ProjectDeleteRequestDto request*/)
    {
        var model = _repository.LoadProject(projectId);
        //var model = _repository.LoadProject(request.ProjectId);

        _repository.DeleteProject(model);
    }
}