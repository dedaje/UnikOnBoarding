using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;
using Unik.Crosscut.TransactionHandling;
using System.Data;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class CreateProjectCommand : ICreateProjectCommand
{
    private readonly IProjectRepository _repository;
    private readonly IProjectDomainService _domainService;
    private readonly IUnitOfWork _uow;
    public CreateProjectCommand(IProjectRepository repository, IProjectDomainService domainService, IUnitOfWork uow)
    {
        _repository = repository;
        _domainService = domainService;
        _uow = uow;
    }

    void ICreateProjectCommand.Create(ProjectCreateRequestDto dto)
    {
        
        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);
            //Read
            var project = new ProjectEntity(dto.ProjectId, dto.ProjectName, dto.UserId, _domainService);
            _repository.Add(project);
           

            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }
    }
}