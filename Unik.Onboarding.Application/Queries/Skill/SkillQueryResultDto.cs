namespace Unik.Onboarding.Application.Queries.Skill;

public class SkillQueryResultDto
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public byte[] RowVersion { get; set; }
}