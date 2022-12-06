using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class UsersEntity
{
    //private readonly IUserDomainService _domainService;

    internal UsersEntity()
    {
    }

    public UsersEntity(List<ProjectEntity> projects, string userId/*, IUserDomainService domainService*/)
    {
        //_domainService = domainService;
        Projects = projects;
        UserId = userId;

        //if (_domainService.userExistsInProject(userId)) throw new ArgumentException("Denne bruger er allerede medlem af dette project");
    }

    public int Id { get; private set; } // PK
    public List<ProjectEntity> Projects { get; private set; } // FK
    public List<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
    public string UserId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(List<ProjectEntity> projects, string userId, byte[] rowVersion)
    {
        Projects = projects;
        UserId = userId;
        RowVersion = rowVersion;
    }
}