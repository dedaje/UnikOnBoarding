using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class TaskEntity
{
    // For Entity Framework only!!!
    internal TaskEntity()
    {
    }

    public TaskEntity(string taskName, string taskDescription, ProjectEntity projects, int roleId, UsersEntity users)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        DateCreated = DateTime.Now;
        Projects = projects;
        RoleId = roleId;
        Users = users;
    }

    public int Id { get; private set; }
    public string TaskName { get; private set; }
    public string TaskDescription { get; private set; }
    public DateTime DateCreated { get; private set; }
    public int ProjectsId { get; private set; }
    public ProjectEntity Projects { get; private set; } // FK
    public int RoleId { get; private set; } //TODO
    public int UsersId { get; private set; }
    public UsersEntity Users { get; private set; } // FK
    [Timestamp]
    public byte[] RowVersion { get; private set; }

    public void Edit(string taskName, string taskDescription, byte[] rowVersion)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        RowVersion = rowVersion;
    }
}