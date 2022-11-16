using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class UserSkillsEntity
{
    // For Entity Framework only!!!
    internal UserSkillsEntity()
    {
    }

    public UserSkillsEntity(int userId, int skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }

    public int Id { get; private set; }
    [ForeignKey("UserId")] public UserEntity UserEntity { get; set; }
    public int UserId { get; private set; }
    [ForeignKey("SkillId")] public SkillsEntity SkillsEntity { get; set; }
    public int SkillId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(int userId, int skillId, byte[] rowVersion)
    {
        UserId = userId;
        SkillId = skillId;
        RowVersion = rowVersion;

        //throw new NotImplementedException();
    }
}