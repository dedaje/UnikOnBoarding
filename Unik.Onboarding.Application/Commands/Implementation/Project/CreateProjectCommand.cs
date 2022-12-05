using Unik.Onboarding.Application.Commands.Project;
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

    void ICreateProjectCommand.Create(ProjectCreateRequestDto dto)
    {
        var project = new ProjectEntity(dto.ProjectId, dto.ProjectName, dto.UserId, _domainService);
        _repository.Add(project);
    }
}