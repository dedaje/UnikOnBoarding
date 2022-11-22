
namespace Unik.Onboarding.Application.Commands.Skill;

public class SkillEditRequestDto
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public byte[] RowVersion { get; set; }
}