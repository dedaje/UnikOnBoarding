using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class OnboardingEntity
{
    // For Entity Framework only!!!
    internal OnboardingEntity()
    {
    }

    public OnboardingEntity(string projectName)
    {
        ProjectName = projectName;
        DateCreated = DateTime.Now;
    }

    public int ProjectId { get; private set; } // PK
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