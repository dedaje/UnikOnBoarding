namespace Unik.Onboarding.Application.Commands.Task;

public class TaskCreateRequestDto
{
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public int ProjectsId { get; set; }
    public string Section { get; set; }
    public int UsersId { get; set; }
}