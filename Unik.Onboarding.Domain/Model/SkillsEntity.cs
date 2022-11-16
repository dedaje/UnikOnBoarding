using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class SkillsEntity
{
    // For Entity Framework only!!!
    internal SkillsEntity()
    {
    }

    public SkillsEntity(string skillName)
    {
        SkillName = skillName;
    }

    public int SkillId { get; } // PK
    public string SkillName { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string skillName, byte[] rowVersion)
    {
        SkillName = skillName;
        RowVersion = rowVersion;

        //throw new NotImplementedException();
    }
}