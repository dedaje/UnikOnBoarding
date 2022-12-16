using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class UsersEntity
{
    //private readonly IUserDomainService _domainService;

    // For Entity Framework only!!!
    internal UsersEntity()
    {
    }

    public UsersEntity(int id, string userId)
    {
        Id = id;
        UserId = userId;
    }

    public UsersEntity(string userId)
    {
        //_domainService = domainService;
        UserId = userId;

        //if (_domainService.UserExistsInProject(userId)) throw new ArgumentException("Denne bruger er allerede medlem af dette project");
    }

    public int Id { get; private set; } // PK
    public List<ProjectEntity> Projects { get; private set; } 
    public List<TaskEntity> Tasks { get; private set; }
    public string UserId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string userId, byte[] rowVersion)
    {
        UserId = userId;
        RowVersion = rowVersion;
    }
}