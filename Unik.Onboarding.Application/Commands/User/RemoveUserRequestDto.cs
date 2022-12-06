namespace Unik.Onboarding.Application.Commands.User;

public class RemoveUserRequestDto
{
    public int ProjectId { get; set; }
    public string UserId { get; set; }
}