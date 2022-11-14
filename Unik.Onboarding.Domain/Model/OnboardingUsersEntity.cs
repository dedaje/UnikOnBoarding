using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class OnboardingUsersEntity
{
    // For Entity Framework only!!!
    internal OnboardingUsersEntity()
    {
    }

    public OnboardingUsersEntity(int projectId, int userId)
    {
        ProjectId = projectId;
        UserId = userId;
    }

    [ForeignKey("ProjectId")] public OnboardingEntity OnboardingEntity { get; set; }
    public int ProjectId { get; private set; }
    [ForeignKey("UserId")] public UserEntity UserEntity { get; set; }
    public int UserId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(int projectId, int userId, byte[] rowVersion)
    {
        ProjectId = projectId;
        UserId = userId;
        RowVersion = rowVersion;

        throw new NotImplementedException();
    }
}