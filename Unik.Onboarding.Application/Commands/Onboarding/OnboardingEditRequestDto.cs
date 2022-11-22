namespace Unik.Onboarding.Application.Commands.Onboarding;

public class OnboardingEditRequestDto
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
}