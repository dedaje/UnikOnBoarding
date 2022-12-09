using System.ComponentModel.DataAnnotations;
using Unik.Onboarding.Domain.DomainServices;

namespace Unik.Onboarding.Domain.Model;

public class ProjectEntity
{
    private readonly IProjectDomainService _domainService;

    // For Entity Framework only!!!
    internal ProjectEntity()
    {
    }

    public ProjectEntity(string projectName, IProjectDomainService domainService)
    {
        _domainService = domainService;
        ProjectName = projectName;
        DateCreated = DateTime.Now;

        if (_domainService.projectAlreadyExists(projectName)) throw new ArgumentException("Et projekt med dette navn findes allerede i db");
    }

    public int Id { get; private set; } // PK
    public List<UsersEntity> Users { get; private set; }
    public List<TaskEntity> Tasks { get; private set; } /*= new List<TaskEntity>();*/
    public string ProjectName { get; private set; }
    public DateTime DateCreated { get; private set; }

    [Timestamp] 
    public byte[] RowVersion { get; private set; }

    public void Edit(string projectName, byte[] rowVersion)
    {
        ProjectName = projectName;
        RowVersion = rowVersion;
    }
}