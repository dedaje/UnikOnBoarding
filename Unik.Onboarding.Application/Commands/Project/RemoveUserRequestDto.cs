namespace Unik.Onboarding.Application.Commands.Project;

public class RemoveUserRequestDto
{
    public int ProjectId { get; set; }
    public string UserId { get; set; }
}