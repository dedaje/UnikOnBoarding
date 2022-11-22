using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class UserSkillsEntity
{
    // For Entity Framework only!!!
    internal UserSkillsEntity()
    {
    }

    public UserSkillsEntity(string userId, int skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }

    public int Id { get; private set; }
    public string UserId { get; private set; } // Email
    [ForeignKey("SkillId")] public SkillsEntity SkillsEntity { get; set; }
    public int SkillId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string userId, int skillId, byte[] rowVersion)
    {
        UserId = userId;
        SkillId = skillId;
        RowVersion = rowVersion;
    }
}