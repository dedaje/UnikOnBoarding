namespace Unik.Onboarding.Application.Commands.Task;

public class TaskCreateRequestDto
{
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public int ProjectId { get; set; }
    public int RoleId { get; set; }
    public string UserId { get; set; }
}