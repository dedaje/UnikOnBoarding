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

    public ProjectEntity(int projectId, string projectName, string userId, IProjectDomainService domainService)
    {
        _domainService = domainService;
        ProjectId = projectId;
        ProjectName = projectName;
        DateAdded = DateTime.Now;
        UserId = userId;

        if (_domainService.projectAlreadyExists(projectId, userId)) throw new ArgumentException("Denne bruger findes allerede i dette projekt");
    }

    public int Id { get; private set; } // PK
    public int ProjectId { get; private set; }
    public string ProjectName { get; private set; }
    public DateTime DateAdded { get; private set; }
    public string UserId { get; private set; }

    [Timestamp] 
    public byte[] RowVersion { get; private set; }

    public void Edit(int projectId, string projectName/*, byte[] rowVersion*/)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        //UserId = userId;
        //RowVersion = rowVersion;
    }
}