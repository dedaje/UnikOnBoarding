using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class ProjectEntity
{
    // For Entity Framework only!!!
    internal ProjectEntity()
    {
    }

    public ProjectEntity(int projectId, string projectName, string userId)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        DateAdded = DateTime.Now;
        UserId = userId;
    }

    public int Id { get; private set; } // PK
    public int ProjectId { get; private set; }
    public string ProjectName { get; private set; }
    public DateTime DateAdded { get; private set; }
    public string UserId { get; private set; }

    [Timestamp] 
    public byte[] RowVersion { get; private set; }

    //public void AddUser(string projectName, string userId, byte[] rowVersion)
    //{
    //    ProjectName = projectName;
    //    UserId = userId;
    //    RowVersion = rowVersion;
    //}

    public void Edit(string projectName/*, byte[] rowVersion*/)
    {
        ProjectName = projectName;
        //UserId = userId;
        //RowVersion = rowVersion;
    }
}