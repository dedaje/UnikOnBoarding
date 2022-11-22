namespace Unik.Onboarding.Application.Commands.UserSkills;

public class UserSkillsEditRequestDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int SkillId { get; set; }
    public byte[] RowVersion { get; set; }
}