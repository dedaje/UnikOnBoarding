using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class CreateProjectCommand : ICreateProjectCommand
{
    private readonly IProjectRepository _repository;

    public CreateProjectCommand(IProjectRepository repository)
    {
        _repository = repository;
    }

    void ICreateProjectCommand.Create(ProjectCreateRequestDto dto)
    {
        var project = new ProjectEntity(dto.ProjectId, dto.ProjectName, dto.UserId);
        _repository.Add(project);
    }
}