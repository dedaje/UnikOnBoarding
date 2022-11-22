using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class OnboardingUsersEntity
{
    // For Entity Framework only!!!
    internal OnboardingUsersEntity()
    {
    }

    public OnboardingUsersEntity(int projectId, string userId)
    {
        ProjectId = projectId;
        UserId = userId;
    }

    public int Id { get; private set; }
    [ForeignKey("ProjectId")] public OnboardingEntity OnboardingEntity { get; set; }
    public int ProjectId { get; private set; }
    //[ForeignKey("UserId")] public UserEntity UserEntity { get; set; }
    public string UserId { get; private set; } //Inde i projekt oversigten vil der være en "Tilføj bruger" knap som tager ProjectId med, når der tilføjes en bruger.

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(int projectId, string userId, byte[] rowVersion)
    {
        ProjectId = projectId;
        UserId = userId;
        RowVersion = rowVersion;
    }
}