using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class TaskEntity
{
    internal TaskEntity()
    {
    }

    public TaskEntity(string taskName, string taskDescription, int projectId, int roleId, string userId)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        DateCreated = DateTime.Now;
        ProjectId = projectId;
        RoleId = roleId;
        UserId = userId;
    }

    public int TaskId { get; private set; }
    public string TaskName { get; private set; }
    public string TaskDescription { get; private set; }
    public DateTime DateCreated { get; private set; }
    [ForeignKey("ProjectId")]public OnboardingEntity OnboardingEntity { get; set; }
    public int ProjectId { get; private set; }
    [ForeignKey("RoleId")] public RoleEntity RoleEntity { get; set; }
    public int RoleId { get; private set; }
    public string UserId { get; private set; } // Email
    public byte[] RowVersion { get; private set; }

    public void Edit(string taskName, string taskDescription, byte[] rowVersion)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        RowVersion = rowVersion;
    }
}